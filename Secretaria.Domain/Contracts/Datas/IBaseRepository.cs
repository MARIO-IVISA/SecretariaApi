using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Secretaria.Domain.Entities;

namespace Secretaria.Domain.Contracts.Datas
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> BuscarPorId(int id);
        Task<TEntity> Inserir(TEntity matricula);
    }
}
