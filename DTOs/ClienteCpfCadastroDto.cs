using System.ComponentModel.DataAnnotations;

namespace AeroHubAPI.DTOs
{
    // DTO para a tela de cadastro Cliente PF (Imagens 1.jpg, 2.jpg, 3.jpg, 4.jpg)
    public class ClienteCpfCadastroDto
    {
        // ID do Usuário já criado na primeira etapa (Login/Senha)
        [Required(ErrorMessage = "O ID do Usuário é obrigatório.")]
        public int IdUsuario { get; set; }

        // --- Dados Pessoais (Tela 1) ---
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [StringLength(255)]
        public string NomeCompleto { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(14)]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [StringLength(20)]
        public string Telefone { get; set; } = string.Empty;

        [Required(ErrorMessage = "O gênero é obrigatório.")]
        [StringLength(20)]
        public string Genero { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }

        // --- Endereço (Tela 2) ---
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

        // --- Documentação (Tela 3) ---
        // Aqui salvamos as URLs após o upload do arquivo
        [Required(ErrorMessage = "A URL da foto da frente do documento é obrigatória.")]
        [StringLength(500)]
        public string DocumentoFrenteUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "A URL da foto do verso do documento é obrigatória.")]
        [StringLength(500)]
        public string DocumentoVersoUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "A URL da foto de perfil é obrigatória.")]
        [StringLength(500)]
        public string FotoPerfilUrl { get; set; } = string.Empty;
    }
}