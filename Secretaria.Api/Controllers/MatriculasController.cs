using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Secretaria.Api.Settings;
using Secretaria.Application.Contracts;
using Secretaria.Application.Models;
using Secretaria.Domain.Entities;
using XAct.Messages;

namespace Secretaria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class MatriculasController : ControllerBase
    {
        private readonly IMatriculaApplicationService _matriculaAppService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MatriculasController(IMatriculaApplicationService matriculaAppService, IHttpContextAccessor httpContextAccessor)
        {
            _matriculaAppService = matriculaAppService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrarluno(MatriculaCadastroModel matricula)
        {
            try
            {
                string authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                if (string.IsNullOrEmpty(authorizationHeader))
                    return Unauthorized();
                await _matriculaAppService.Inserir(matricula, authorizationHeader);

                return StatusCode(200, new { message = "Nota atualizada com sucesso!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpPut]
        public async Task<IActionResult> AtualizarNota(AtualizarNotaModel nota)
        {
            try
            {
                string authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                if (string.IsNullOrEmpty(authorizationHeader))
                    return Unauthorized();

                await _matriculaAppService.AtualizaNota(nota, authorizationHeader);

                return StatusCode(200, new { message = "Nota atualizada com sucesso!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpPost("VerificarMatricula")]
        public async Task<IActionResult> VerificarMatricula(MatriculaCadastroModel aluno)
        {
            var matricula = await _matriculaAppService.VerificarMatricula(aluno);
            return StatusCode(200, matricula);
        }

        [HttpGet("BuscarMatriculaPorAluno/{idAluno}")]
        public async Task<IActionResult> BuscarMatriculaPorAluno(Guid idAluno)
        {
            string authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authorizationHeader))
                return Unauthorized();

            var noticia = await _matriculaAppService.BuscarPorAluno(idAluno, authorizationHeader);
            return StatusCode(200, noticia);
        }

        [HttpGet("BuscarMatriculaPorCurso/{idCurso}")]
        public async Task<IActionResult> BuscarMatriculaPorCurso(Guid idCurso)
        {
            string authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authorizationHeader))
                return Unauthorized();

            var noticia = await _matriculaAppService.BuscarPorCurso(idCurso, authorizationHeader);
            return Ok(noticia);
        }
    }
}
