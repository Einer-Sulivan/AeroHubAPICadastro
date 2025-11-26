using Microsoft.AspNetCore.Http; // Para usar IFormFile

namespace AeroHubAPI.Services.Interfaces
{
    public interface IArquivoService
    {
        /// <summary>
        /// Salva o arquivo no servidor e retorna o caminho/URL relativa.
        /// </summary>
        // <param name="file">O arquivo recebido da requisição HTTP.</param>
        // <param name="subDir">O subdiretório onde o arquivo será salvo (ex: "documentos", "perfil").</param>
        /// <returns>O caminho relativo ou URL do arquivo.</returns>
        Task<string> SalvarArquivoLocalAsync(IFormFile file, string subDir);
    }
}