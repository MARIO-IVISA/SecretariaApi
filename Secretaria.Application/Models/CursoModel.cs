using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secretaria.Application.Models
{
    public class CursoModel
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public Guid? IdProfessor { get; set; }
        public double? Media { get; set; }
        public DateTime DataCurso { get; set; }
    }
}
