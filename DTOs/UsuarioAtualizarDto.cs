namespace AeroHubAPI.DTOs
{
    public class UsuarioAtualizarDto
    {
        public string? EmailUsuario { get; set; }
        public string? SenhaUsuario { get; set; }
        public string? TipoCadastroUsuario { get; set; }
        public string? StatusContaUsuario { get; set; }
    }
}