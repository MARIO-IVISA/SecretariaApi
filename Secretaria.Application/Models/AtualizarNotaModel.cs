using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secretaria.Application.Models
{
    public class AtualizarNotaModel
    {
        public int id { get; set; }
        public decimal? nota { get; set; }
        public int? media { get; set; }
    }
}
