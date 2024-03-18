using Secretaria.Domain.Contracts.Datas;
using Secretaria.Domain.Contracts.Services;
using Secretaria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secretaria.Domain.Service
{
    public class MatriculaDomainService : IMatriculaDomainService
    {
        private readonly IMatriculaRepository _repository;

        public MatriculaDomainService(IMatriculaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Matricula> Inserir(Matricula matricula)
        {
            return await _repository.Inserir(matricula);
        }

        public async Task<ICollection<Matricula>> BuscarPorCurso(Guid idCurso)
        {
            return await _repository.BuscarPorCurso(idCurso);
        }

        public async Task<ICollection<Matricula>> BuscarPorAluno(Guid idAluno)
        {
            return await _repository.BuscarPorAluno(idAluno);
        }

        public async Task<Matricula> AtualizaNota(Matricula matricula)
        {
            return await _repository.AtualizaNota(matricula);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public async Task<Matricula> BuscarPorId(int id)
        {
            return await _repository.BuscarPorId(id);
        }

        public async Task<Matricula> BuscarPorAlunoCurso(Guid alunoId, Guid cursoId)
        {
            return await _repository.BuscarPorAlunoCurso(alunoId, cursoId);
        }

        public async Task<Matricula> VerificarMatricula(Guid idUsuario, Guid idCurso)
        {
            return await _repository.VerificarMatricula(idUsuario, idCurso);
        }
    }
}
