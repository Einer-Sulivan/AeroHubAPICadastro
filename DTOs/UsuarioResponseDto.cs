namespace AeroHubAPI.DTOs
{
    public class UsuarioResponseDto
    {
        public int IdUsuario { get; set; }
        public string EmailUsuario { get; set; } = string.Empty;
        public string? TipoCadastroUsuario { get; set; }
        public DateTime DataCriacaoControleUsuario { get; set; }
        public bool TermosAceitosUsuario { get; set; }
        public DateTime? DataAceiteTermosUsuario { get; set; }
        public string StatusContaUsuario { get; set; } = string.Empty;
    }
}