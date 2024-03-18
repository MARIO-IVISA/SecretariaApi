using Newtonsoft.Json;
using Secretaria.Api.Settings;
using Secretaria.Application.Contracts;
using Secretaria.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Secretaria.Application.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UsuarioExistenteModel> ObterUsuarioPorId(Guid id)
        {
            var response = await _httpClient.GetAsync($"{AppSettings.ApiUsuarios}usuariosPorId/{id}");
            var content = await response.Content.ReadAsStringAsync();

            var usuarioExistenteModel = JsonConvert.DeserializeObject<UsuarioExistenteModel>(content);

            return usuarioExistenteModel;
        }

        public async Task<CursoModel> ObterCursosPorId(Guid id, string token)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await httpClient.GetAsync($"{AppSettings.ApiCursos}Cursos/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var cursoModel = JsonConvert.DeserializeObject<CursoModel>(content);
                    return cursoModel;
                }
                else
                {
                    throw new Exception($"Falha ao obter o curso. StatusCode: {response.StatusCode}");
                }
            }
        }

    }
}
