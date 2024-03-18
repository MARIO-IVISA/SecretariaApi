using Newtonsoft.Json;
using Secretaria.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace Secretaria.Application.Models
{
    public class UsuarioExistenteModel
    {
        [JsonProperty("usuario")]
        public UsuarioModel Usuario { get; set; }
    }
    public class UsuarioModel
    {
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }
        public decimal? Nota { get; set; }
        public int? Id { get; set; }
        public StatusAprovacao? Status { get; set; }
    }
}
