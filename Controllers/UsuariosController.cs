using AeroHubAPI.DTOs;
using AeroHubAPI.Services.Interfaces; // NOVO
using Microsoft.AspNetCore.Mvc;
using System.Net; // Para melhor controle dos códigos de erro

namespace AeroHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // Alterado de ApplicationDbContext para IUsuarioService
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService) // Injeção de Dependência do Service
        {
            _usuarioService = usuarioService;
        }

        // GET: api/usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioResponseDto>>> GetUsuarios()
        {
            var usuarios = await _usuarioService.GetAllUsuariosAsync();

            // Mapeamento DTO
            var response = usuarios.Select(u => new UsuarioResponseDto
            {
                IdUsuario = u.IdUsuario,
                EmailUsuario = u.EmailUsuario,
                TipoCadastroUsuario = u.TipoCadastroUsuario,
                DataCriacaoControleUsuario = u.DataCriacaoControleUsuario,
                TermosAceitosUsuario = u.TermosAceitosUsuario,
                DataAceiteTermosUsuario = u.DataAceiteTermosUsuario,
                StatusContaUsuario = u.StatusContaUsuario
            }).ToList();

            return Ok(response);
        }

        // GET: api/usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioResponseDto>> GetUsuario(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);

            if (usuario == null)
            {
                return NotFound(new { message = "Usuário não encontrado" });
            }

            // Mapeamento DTO
            var response = new UsuarioResponseDto
            {
                IdUsuario = usuario.IdUsuario,
                EmailUsuario = usuario.EmailUsuario,
                TipoCadastroUsuario = usuario.TipoCadastroUsuario,
                DataCriacaoControleUsuario = usuario.DataCriacaoControleUsuario,
                TermosAceitosUsuario = usuario.TermosAceitosUsuario,
                DataAceiteTermosUsuario = usuario.DataAceiteTermosUsuario,
                StatusContaUsuario = usuario.StatusContaUsuario
            };

            return Ok(response);
        }

        // POST: api/usuarios
        [HttpPost]
        public async Task<ActionResult<UsuarioResponseDto>> PostUsuario(UsuarioCriarDto usuarioDto)
        {
            try
            {
                var usuario = await _usuarioService.CriarUsuarioAsync(usuarioDto);

                // Mapeamento DTO
                var response = new UsuarioResponseDto
                {
                    IdUsuario = usuario.IdUsuario,
                    EmailUsuario = usuario.EmailUsuario,
                    TipoCadastroUsuario = usuario.TipoCadastroUsuario,
                    DataCriacaoControleUsuario = usuario.DataCriacaoControleUsuario,
                    TermosAceitosUsuario = usuario.TermosAceitosUsuario,
                    DataAceiteTermosUsuario = usuario.DataAceiteTermosUsuario,
                    StatusContaUsuario = usuario.StatusContaUsuario
                };

                return CreatedAtAction(nameof(GetUsuario), new { id = usuario.IdUsuario }, response);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("Email já cadastrado"))
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "Ocorreu um erro interno ao criar o usuário." });
            }
        }

        // PUT: api/usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioAtualizarDto usuarioDto)
        {
            try
            {
                var usuario = await _usuarioService.UpdateUsuarioAsync(id, usuarioDto);

                if (usuario == null)
                {
                    // Lógica para tratar DbUpdateConcurrencyException e Not Found está no Service
                    if (!await _usuarioService.UsuarioExistsAsync(id))
                    {
                        return NotFound(new { message = "Usuário não encontrado" });
                    }
                    // Outro erro de concorrência ou atualização
                    return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "Ocorreu um erro ao atualizar o usuário." });
                }

                return NoContent();
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("Email já em uso"))
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "Ocorreu um erro interno ao atualizar o usuário." });
            }
        }

        // DELETE: api/usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var isDeleted = await _usuarioService.DeleteUsuarioAsync(id);

            if (!isDeleted)
            {
                return NotFound(new { message = "Usuário não encontrado" });
            }

            return NoContent();
        }
    }
}