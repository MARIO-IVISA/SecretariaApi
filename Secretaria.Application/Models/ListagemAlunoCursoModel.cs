using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secretaria.Application.Models
{
    public class ListagemAlunoCursoModel
    {
        public virtual CursoModel Curso { get; set; }
        public virtual List<UsuarioModel> ListagemAlunoCurso { get; set; }
    }

}
