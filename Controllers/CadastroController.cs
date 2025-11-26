using AeroHubAPI.DTOs;
using AeroHubAPI.Services;
using AeroHubAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AeroHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly ICadastroService _cadastroService;

        public CadastroController(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        // --- ENDPOINTS DE CLIENTE (JÁ VISTOS) ---
        // Exemplo de como devem ser os endpoints de Cliente (Contratante)

        [HttpPost("cliente/cpf")]
        public async Task<IActionResult> CadastrarClienteCpf([FromBody] ClienteCpfCadastroDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var pessoa = await _cadastroService.CadastrarClienteCpfAsync(dto);
                return Ok(new { mensagem = "Cadastro de Cliente CPF concluído.", idPessoa = pessoa.IdPessoa });
            }
            catch (Exception ex)
            {
                if (ex is KeyNotFoundException || ex is InvalidOperationException) return BadRequest(new { message = ex.Message });
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "Erro interno ao processar o cadastro de Cliente CPF." });
            }
        }

        [HttpPost("cliente/cnpj")]
        public async Task<IActionResult> CadastrarClienteCnpj([FromBody] ClienteCnpjCadastroDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var pessoa = await _cadastroService.CadastrarClienteCnpjAsync(dto);
                return Ok(new { mensagem = "Cadastro de Cliente CNPJ concluído.", idPessoa = pessoa.IdPessoa });
            }
            catch (Exception ex)
            {
                if (ex is KeyNotFoundException || ex is InvalidOperationException) return BadRequest(new { message = ex.Message });
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "Erro interno ao processar o cadastro de Cliente CNPJ." });
            }
        }

        // --- NOVOS ENDPOINTS DE PILOTO ---

        // Endpoint para o fluxo de Piloto CPF
        [HttpPost("piloto/cpf")]
        public async Task<IActionResult> CadastrarPilotoCpf([FromBody] PilotoCpfCadastroDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var pessoa = await _cadastroService.CadastrarPilotoCpfAsync(dto);

                return Ok(new
                {
                    mensagem = "Cadastro de Piloto CPF concluído com sucesso.",
                    idPessoa = pessoa.IdPessoa,
                    idUsuario = pessoa.IdUsuario
                });
            }
            catch (Exception ex)
            {
                if (ex is KeyNotFoundException || ex is InvalidOperationException) return BadRequest(new { message = ex.Message });
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "Erro interno ao processar o cadastro de Piloto CPF." });
            }
        }

        // Endpoint para o fluxo de Piloto CNPJ
        [HttpPost("piloto/cnpj")]
        public async Task<IActionResult> CadastrarPilotoCnpj([FromBody] PilotoCnpjCadastroDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var pessoa = await _cadastroService.CadastrarPilotoCnpjAsync(dto);

                return Ok(new
                {
                    mensagem = "Cadastro de Piloto CNPJ concluído com sucesso.",
                    idPessoa = pessoa.IdPessoa,
                    idUsuario = pessoa.IdUsuario
                });
            }
            catch (Exception ex)
            {
                if (ex is KeyNotFoundException || ex is InvalidOperationException) return BadRequest(new { message = ex.Message });
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "Erro interno ao processar o cadastro de Piloto CNPJ." });
            }
        }
    }
}