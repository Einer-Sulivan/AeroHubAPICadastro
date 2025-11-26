using System.ComponentModel.DataAnnotations;

namespace AeroHubAPI.DTOs
{
    // DTO para o cadastro Piloto PF (Pessoa Física)
    public class PilotoCpfCadastroDto
    {
        [Required(ErrorMessage = "O ID do Usuário é obrigatório.")]
        public int IdUsuario { get; set; }

        // --- Dados Pessoais ---
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [StringLength(255)]
        public string NomeCompleto { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(14)]
        public string Cpf { get; set; } = string.Empty;

        // Campo adicional para Piloto/RG
        [StringLength(20)]
        public string? Rg { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [StringLength(20)]
        public string Telefone { get; set; } = string.Empty;

        [Required(ErrorMessage = "O gênero é obrigatório.")]
        [StringLength(20)]
        public string Genero { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }

        [StringLength(255)]
        public string? TituloProfissional { get; set; }

        // --- Endereço ---
        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [StringLength(10)]
        public string Cep { get; set; } = string.Empty;

        [Required(ErrorMessage = "O logradouro é obrigatório.")]
        [StringLength(255)]
        public string Logradouro { get; set; } = string.Empty;

        [Required(ErrorMessage = "O bairro é obrigatório.")]
        [StringLength(100)]
        public string Bairro { get; set; } = string.Empty;

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        [StringLength(100)]
        public string Cidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "O estado é obrigatório.")]
        [StringLength(2)]
        public string Estado { get; set; } = string.Empty;

        [StringLength(20)]
        public string? Numero { get; set; }

        [StringLength(255)]
        public string? Complemento { get; set; }

        // --- Documentação ---
        [Required(ErrorMessage = "A URL da foto da frente do documento é obrigatória.")]
        [StringLength(500)]
        public string DocumentoFrenteUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "A URL da foto do verso do documento é obrigatória.")]
        [StringLength(500)]
        public string DocumentoVersoUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "A URL da foto de perfil é obrigatória.")]
        [StringLength(500)]
        public string FotoPerfilUrl { get; set; } = string.Empty;

        // Outros campos específicos do Piloto (Ex: ANAC, Drone license)
        // ...
    }
}