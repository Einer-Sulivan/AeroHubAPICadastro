using AeroHubAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace AeroHubAPI.Services
{
    public class ArquivoService : IArquivoService
    {
        private readonly IWebHostEnvironment _env;

        // IWebHostEnvironment é injetado para obter o caminho raiz da aplicação
        public ArquivoService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> SalvarArquivoLocalAsync(IFormFile file, string subDir)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("O arquivo é inválido ou está vazio.");
            }

            // 1. Define o caminho do diretório de destino (ex: wwwroot/uploads/documentos)
            var uploadPath = Path.Combine(_env.WebRootPath, "uploads", subDir);

            // 2. Cria o diretório se ele não existir
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            // 3. Gera um nome de arquivo único para evitar colisões
            var extension = Path.GetExtension(file.FileName);
            var uniqueFileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(uploadPath, uniqueFileName);

            // 4. Salva o arquivo no disco
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // 5. Retorna o caminho que será salvo no banco de dados
            // Retorna o caminho relativo: /uploads/documentos/nome-unico.jpg
            return $"/uploads/{subDir}/{uniqueFileName}";
        }
    }
}