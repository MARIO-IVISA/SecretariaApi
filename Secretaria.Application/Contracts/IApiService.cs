using Secretaria.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secretaria.Application.Contracts
{
    public interface IApiService
    {
        Task<UsuarioExistenteModel> ObterUsuarioPorId(Guid id);
        Task<CursoModel> ObterCursosPorId(Guid id, string token);
    }
}
