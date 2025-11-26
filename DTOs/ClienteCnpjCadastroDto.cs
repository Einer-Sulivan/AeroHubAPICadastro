using System.ComponentModel.DataAnnotations;

namespace AeroHubAPI.DTOs
{
    // DTO para o cadastro Cliente PJ (Empresa) (Imagens 1.jpg, 2.jpg, 3.jpg, 4.png)
    public class ClienteCnpjCadastroDto
    {
        [Required(ErrorMessage = "O ID do Usuário é obrigatório.")]
        public int IdUsuario { get; set; }

        // --- Dados da Empresa (Tela 1 - Parte CNPJ) ---
        [Required(ErrorMessage = "A razão social é obrigatória.")]
        [StringLength(255)]
        public string RazaoSocial { get; set; } = string.Empty;

        [Required(ErrorMessage = "O nome fantasia é obrigatório.")]
        [StringLength(255)]
        public string NomeFantasia { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [StringLength(18)]
        public string Cnpj { get; set; } = string.Empty;

        [StringLength(50)]
        public string? InscricaoEstadual { get; set; }

        [StringLength(50)]
        public string? InscricaoMunicipal { get; set; }

        [Required(ErrorMessage = "O porte da empresa é obrigatório.")]
        [StringLength(50)]
        public string PorteEmpresa { get; set; } = string.Empty;

        // --- Dados do Representante Legal (Tela 1 - Parte Representante) ---
        [Required(ErrorMessage = "O nome do representante é obrigatório.")]
        [StringLength(255)]
        public string NomeRepresentante { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF do representante é obrigatório.")]
        [StringLength(14)]
        public string CpfRepresentante { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail do representante é obrigatório.")]
        [EmailAddress]
        [StringLength(255)]
        public string EmailRepresentante { get; set; } = string.Empty;

        [Required(ErrorMessage = "O telefone do representante é obrigatório.")]
        [StringLength(20)]
        public string TelefoneRepresentante { get; set; } = string.Empty;

        [Required(ErrorMessage = "O cargo do representante é obrigatório.")]
        [StringLength(100)]
        public string CargoRepresentante { get; set; } = string.Empty;

        // --- Endereço (Tela 2 - igual ao CPF) ---
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
        [Required(ErrorMessage = "A URL do documento CNPJ é obrigatória.")]
        [StringLength(500)]
        public string DocumentoCnpjUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "A URL do Contrato Social é obrigatória.")]
        [StringLength(500)]
        public string ContratoSocialUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "A URL da Logo da empresa é obrigatória.")]
        [StringLength(500)]
        public string LogoCnpjUrl { get; set; } = string.Empty;
    }
}