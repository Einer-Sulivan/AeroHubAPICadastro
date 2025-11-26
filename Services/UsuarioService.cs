using AeroHubAPI.Data;
using AeroHubAPI.DTOs;
using AeroHubAPI.Models;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using AeroHubAPI.Services.Interfaces; // Adicionado

namespace AeroHubAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> EmailExistsAsync(string email, int? excludeId = null)
        {
            // Se excludeId for fornecido, verifica se o email existe em outro usuário.
            if (excludeId.HasValue)
            {
                return await _context.Usuarios.AnyAsync(u => u.EmailUsuario == email && u.IdUsuario != excludeId.Value);
            }
            // Caso contrário, verifica se o email existe.
            return await _context.Usuarios.AnyAsync(u => u.EmailUsuario == email);
        }

        public async Task<bool> UsuarioExistsAsync(int id)
        {
            return await _context.Usuarios.AnyAsync(e => e.IdUsuario == id);
        }

        public async Task<Usuario> CriarUsuarioAsync(UsuarioCriarDto usuarioDto)
        {
            // Validação de negócio: Email já existe (movida do Controller)
            if (await EmailExistsAsync(usuarioDto.EmailUsuario))
            {
                // Em um Service, geralmente lançamos uma exceção para o Controller capturar.
                throw new InvalidOperationException("Email já cadastrado.");
            }

            var usuario = new Usuario
            {
                EmailUsuario = usuarioDto.EmailUsuario,
                // Lógica de hashing movida para o Service
                SenhaUsuario = BCrypt.Net.BCrypt.HashPassword(usuarioDto.SenhaUsuario),
                TipoCadastroUsuario = usuarioDto.TipoCadastroUsuario,
                TermosAceitosUsuario = usuarioDto.TermosAceitosUsuario,
                DataAceiteTermosUsuario = usuarioDto.TermosAceitosUsuario ? DateTime.Now : null,
                // DataCriacaoControleUsuario e StatusContaUsuario são preenchidos por default no Model
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario?> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        // Implementar outros métodos...
        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> UpdateUsuarioAsync(int id, UsuarioAtualizarDto usuarioDto)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return null; // Usuário não encontrado
            }

            // Validação de email para atualização
            if (!string.IsNullOrEmpty(usuarioDto.EmailUsuario) &&
                await EmailExistsAsync(usuarioDto.EmailUsuario, id))
            {
                throw new InvalidOperationException("Email já em uso por outro usuário.");
            }

            // Lógica de atualização
            if (!string.IsNullOrEmpty(usuarioDto.EmailUsuario))
            {
                usuario.EmailUsuario = usuarioDto.EmailUsuario;
            }

            if (!string.IsNullOrEmpty(usuarioDto.SenhaUsuario))
            {
                usuario.SenhaUsuario = BCrypt.Net.BCrypt.HashPassword(usuarioDto.SenhaUsuario);
            }

            if (!string.IsNullOrEmpty(usuarioDto.TipoCadastroUsuario))
            {
                usuario.TipoCadastroUsuario = usuarioDto.TipoCadastroUsuario;
            }

            if (!string.IsNullOrEmpty(usuarioDto.StatusContaUsuario))
            {
                usuario.StatusContaUsuario = usuarioDto.StatusContaUsuario;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await UsuarioExistsAsync(id))
                {
                    return null;
                }
                throw;
            }

            return usuario;
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}