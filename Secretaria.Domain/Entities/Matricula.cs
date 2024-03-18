using Secretaria.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secretaria.Domain.Entities
{
    public class Matricula
    {
        public int Id { get; set; }
        public Guid CursoId { get; set; }
        public Guid AlunosId { get; set; }
        public decimal? Nota { get; set; }
        public StatusAprovacao Status { get; set; }
    }
}
