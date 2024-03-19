using Secretaria.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secretaria.WorkerService.Models
{
    public class AlunoModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string NomeCurso { get; set; }
        public StatusAprovacao StatusAprovacao { get; set; }
    }
}
