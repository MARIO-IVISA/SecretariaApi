using Secretaria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secretaria.Domain.Contracts.Datas
{
    public interface IMatriculaRepository : IBaseRepository<Matricula>
    {
        Task<ICollection<Matricula>> BuscarPorCurso(Guid idCurso);
        Task<ICollection<Matricula>> BuscarPorAluno(Guid idAluno);
        Task<Matricula> BuscarPorAlunoCurso(Guid alunoId, Guid cursoId);
        Task<Matricula> AtualizaNota(Matricula matricula);
        Task<Matricula> VerificarMatricula(Guid idUsuario, Guid idCurso);

    }
}
