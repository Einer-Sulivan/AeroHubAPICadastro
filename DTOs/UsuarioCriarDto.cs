using System.ComponentModel.DataAnnotations;

namespace AeroHubAPI.DTOs
{
    public class UsuarioCriarDto
    {
        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string EmailUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "Senha é obrigatória")]
        [MinLength(6, ErrorMessage = "Senha deve ter no mínimo 6 caracteres")]
        public string SenhaUsuario { get; set; } = string.Empty;

        public string? TipoCadastroUsuario { get; set; }
        public bool TermosAceitosUsuario { get; set; }
    }
}