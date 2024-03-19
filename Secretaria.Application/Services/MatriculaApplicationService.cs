using AutoMapper;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Secretaria.Api.Settings;
using Secretaria.Application.Contracts;
using Secretaria.Application.Models;
using Secretaria.Core.Enums;
using Secretaria.Domain.Contracts.Services;
using Secretaria.Domain.Entities;
using Secretaria.Infrastructure.Migrations;
using Secretaria.WorkerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XAct;
using XAct.Messages;

namespace Secretaria.Application.Services
{
    public class MatriculaApplicationService : IMatriculaApplicationService
    {
        private readonly IMatriculaDomainService _matriculaDomainService;
        private IMapper _mapper;
        private IApiService _apiService;
        private readonly IConfiguration _configuration;
        private readonly QueueClient _queueClient;

        public MatriculaApplicationService(IMatriculaDomainService matriculaDomainService, IMapper mapper, IApiService apiService)
        {
            _matriculaDomainService = matriculaDomainService;
            _mapper = mapper;
            _apiService = apiService;
            _queueClient = new QueueClient(AppSettings.ConnectionStringServiceBus, AppSettings.NomeFilaServiceBus);
        }

        public async Task<Matricula> Inserir(MatriculaCadastroModel model, string authorizationHeader)
        {
            string token = authorizationHeader.Replace("Bearer ", "");

            var verificaMatricula = _matriculaDomainService.BuscarPorAlunoCurso(model.AlunosId, model.CursoId);
            if (verificaMatricula.Result != null)
                throw new ArgumentException("O aluno já está matriculado nesse curso.");

            Matricula aluno = _mapper.Map<Matricula>(model);

            await CriarMensagem(aluno, token);

            return await _matriculaDomainService.Inserir(aluno);
        }

        public async Task<ListagemAlunoCursoModel> BuscarPorCurso(Guid idCurso, string authorizationHeader)
        {
            string token = authorizationHeader.Replace("Bearer ", "");
            var cursoModel = await _matriculaDomainService.BuscarPorCurso(idCurso);
            var curso = await _apiService.ObterCursosPorId(idCurso, token);

            var modelo = new ListagemAlunoCursoModel
            {
                Curso = curso,
                ListagemAlunoCurso = new List<UsuarioModel>()
            };

            var tasks = cursoModel.Select(async matricula =>
            {
                var aluno = await _apiService.ObterUsuarioPorId(matricula.AlunosId);
                aluno.Usuario.Id = matricula.Id;
                aluno.Usuario.Nota = matricula.Nota;
                aluno.Usuario.Status = matricula.Status;
                return aluno.Usuario;
            });

            var alunos = await Task.WhenAll(tasks);
            modelo.ListagemAlunoCurso.AddRange(alunos);

            return modelo;
        }


        public async Task<ListagemHistoricoAlunoViewModel> BuscarPorAluno(Guid idAluno, string authorizationHeader)
        {
            string token = authorizationHeader.Replace("Bearer ", "");
            var aluno = await _apiService.ObterUsuarioPorId(idAluno);
            var alunoModel = await _matriculaDomainService.BuscarPorAluno(idAluno);

            var historico = alunoModel.Select(async matricula =>
            {
                var modelHistorico = new CursoParaHistorico();
                modelHistorico.Curso = await _apiService.ObterCursosPorId(matricula.CursoId, token);
                modelHistorico.Nota = matricula.Nota;
                modelHistorico.IdMatricula = matricula.Id;
                modelHistorico.Status = matricula.Status;
                return modelHistorico;
            });

            return new ListagemHistoricoAlunoViewModel
            {
                NomeAluno = aluno.Usuario.Nome,
                Email = aluno.Usuario.Email,
                IdAluno = idAluno,
                Historico = (await Task.WhenAll(historico)).ToList()
            };
        }

        public async Task<Matricula> AtualizaNota(AtualizarNotaModel matricula, string authorizationHeader)
        {
            string token = authorizationHeader.Replace("Bearer ", "");


            var matriculaExistente = await _matriculaDomainService.BuscarPorId(matricula.id);
            if (matriculaExistente == null)
                throw new ArgumentException("Matrícula não encontrada.");

            matriculaExistente.Nota = matricula.nota;
            matriculaExistente.Status = matricula.nota >= matricula.media ? StatusAprovacao.Aprovado : StatusAprovacao.Reprovado;
            
            await CriarMensagem(matriculaExistente, token);

            return await _matriculaDomainService.AtualizaNota(matriculaExistente);
        }

        public void Dispose()
        {
            _matriculaDomainService.Dispose();
        }

        public async Task<string> VerificarMatricula(MatriculaCadastroModel matricula)
        {
            var aluno = await _matriculaDomainService.VerificarMatricula(matricula.AlunosId, matricula.CursoId);
            if (aluno != null)
            {
                return $"Matriculado";
            }
            return "Disponível";
        }
        
        public async Task<string> CriarMensagem(Matricula matricula, string token)
        {
            var aluno = await _apiService.ObterUsuarioPorId(matricula.AlunosId);
            var curso = await _apiService.ObterCursosPorId(matricula.CursoId, token);
            AlunoModel model = new AlunoModel();
            model.Email = aluno.Usuario.Email;
            model.Nome = aluno.Usuario.Nome;
            model.StatusAprovacao = StatusAprovacao.Aprovado;
            model.NomeCurso = curso.Nome;

            return "Aluno Criado";
        }
        public async Task<string> EnviarMensagem(AlunoModel model)
        {
            var inputModelJsonString = JsonConvert.SerializeObject(model);

            var messageBytes = Encoding.UTF8.GetBytes(inputModelJsonString);

            var message = new Microsoft.Azure.ServiceBus.Message(messageBytes);

            await _queueClient.SendAsync(message);

            return "Enviado mensagem";
        }
    }
}
