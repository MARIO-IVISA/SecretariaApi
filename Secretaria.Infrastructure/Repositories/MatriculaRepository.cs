using Microsoft.EntityFrameworkCore;
using Secretaria.Domain.Contracts.Datas;
using Secretaria.Domain.Entities;
using Secretaria.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using XAct;

namespace Secretaria.Infrastructure.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly SqlServerContext _contexto;

        public MatriculaRepository()
        {
            _contexto = new SqlServerContext();
        }

        public async Task<ICollection<Matricula>> BuscarPorCurso(Guid idCurso)
        {
            try
            {
                return await _contexto.Matricula.Where(x => x.CursoId == idCurso).ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao obter alunos por curso.");
            }
        }

        public async Task<ICollection<Matricula>> BuscarPorAluno(Guid idAluno)
        {
            try
            {
                return await _contexto.Matricula.Where(x => x.AlunosId == idAluno).ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao obter cursos por aluno.");
            }
        }

        public async Task<Matricula> AtualizaNota(Matricula matricula)
        {

            using var trans = _contexto.Database.BeginTransaction();
            try
            {
                _contexto.Entry(matricula).State = EntityState.Modified;
                _contexto.SaveChanges();

                trans.Commit();
                return matricula;
            }
            catch (Exception err)
            {
                trans.Rollback();
                throw new Exception($"Erro ao atualizar nota. {err}");
            }
        }
        public async Task<Matricula> Inserir(Matricula matricula)
        {
            _contexto.Matricula.Add(matricula);
            await _contexto.SaveChangesAsync();

            return matricula;
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        public async Task<Matricula> BuscarPorId(int id)
        {
            return await _contexto.Matricula.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Matricula> BuscarPorAlunoCurso(Guid alunoId, Guid cursoId)
        {
            return await _contexto.Matricula.SingleOrDefaultAsync(x => x.AlunosId == alunoId && x.CursoId == cursoId);

        }

        public async Task<Matricula> VerificarMatricula(Guid idUsuario, Guid idCurso)
        {
            return await _contexto.Matricula.Where(x => x.AlunosId == idUsuario && x.CursoId == idCurso).FirstOrDefaultAsync();

        }
    }
}
