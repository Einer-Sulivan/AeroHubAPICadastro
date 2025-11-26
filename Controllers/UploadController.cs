using AeroHubAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AeroHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IArquivoService _arquivoService;

        public UploadController(IArquivoService arquivoService)
        {
            _arquivoService = arquivoService;
        }

        /// <summary>
        /// Realiza o upload de um arquivo e retorna a URL relativa para salvar no banco.
        /// </summary>
        /// <param name="file">O arquivo (IFormFile) a ser enviado.</param>
        /// <param name="subDir">O subdiretório para organizar o arquivo (ex: 'documentos', 'logos', 'perfil').</param>
        /// <returns>A URL relativa do arquivo.</returns>
        [HttpPost("{subDir}")]
        [Consumes("multipart/form-data")] // Indica que a requisição recebe arquivos
        public async Task<IActionResult> UploadArquivo([FromRoute] string subDir, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { message = "Nenhum arquivo enviado ou o arquivo está vazio." });
            }

            // Limpeza básica do subDir para segurança
            subDir = subDir.ToLowerInvariant().Replace("..", "").Trim('/');

            try
            {
                // 1. Salva o arquivo e obtém o caminho
                var filePath = await _arquivoService.SalvarArquivoLocalAsync(file, subDir);

                // 2. Retorna o caminho que deve ser salvo nos DTOs de cadastro (Ex: ClienteCpfCadastroDto)
                return Ok(new
                {
                    message = "Upload realizado com sucesso.",
                    url = filePath
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "Erro interno ao processar o upload do arquivo." });
            }
        }
    }
}