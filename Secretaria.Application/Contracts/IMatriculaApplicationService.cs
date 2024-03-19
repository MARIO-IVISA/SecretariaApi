using Secretaria.Application.Models;
using Secretaria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secretaria.Application.Contracts
{
    public interface IMatriculaApplicationService : IDisposable
    {
        Task<Matricula> Inserir(MatriculaCadastroModel matricula,string authorizationHeader);
        Task<string> VerificarMatricula(MatriculaCadastroModel matricula);
        Task<ListagemAlunoCursoModel> BuscarPorCurso(Guid idCurso, string authorizationHeader);
        Task<ListagemHistoricoAlunoViewModel> BuscarPorAluno(Guid idAluno, string authorizationHeader);
        Task<Matricula> AtualizaNota(AtualizarNotaModel matricula, string authorizationHeader);
    }
}

