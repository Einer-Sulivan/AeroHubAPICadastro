using AeroHubAPI.DTOs;
using AeroHubAPI.Models;

namespace AeroHubAPI.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> CriarUsuarioAsync(UsuarioCriarDto usuarioDto);
        Task<Usuario?> GetUsuarioByIdAsync(int id);
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
        Task<Usuario?> UpdateUsuarioAsync(int id, UsuarioAtualizarDto usuarioDto);
        Task<bool> DeleteUsuarioAsync(int id);
        Task<bool> EmailExistsAsync(string email, int? excludeId = null);
        Task<bool> UsuarioExistsAsync(int id);
    }
}