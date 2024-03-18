using Secretaria.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Secretaria.Application.Models
{
    public class ListagemHistoricoAlunoViewModel
    {
        [JsonPropertyName("nome")]
        public string? NomeAluno { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }
        public Guid? IdAluno { get; set; }
        public List<CursoParaHistorico> Historico { get; set; }
    }

    public class CursoParaHistorico
    {
        public CursoModel Curso { get; set; }
        public decimal? Nota { get; set; }
        public int? IdMatricula { get; set; }
        public StatusAprovacao? Status { get; set; }
    }
}
