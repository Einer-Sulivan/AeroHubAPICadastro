using System.ComponentModel.DataAnnotations;

namespace AeroHubAPI.DTOs
{
    // DTO ÚNICO para o cadastro Piloto PJ (Pessoa Jurídica)
    public class PilotoCnpjCadastroDto
    {
        [Required(ErrorMessage = "O ID do Usuário é obrigatório.")]
        public int IdUsuario { get; set; }

        // --- Dados da Empresa (Tabela Pessoa) ---
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

        // --- Dados do Representante Legal (Tabela RepresentanteLegalCnpjPessoa) ---
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

        // --- Endereço (Tabela Endereco) ---
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

        // --- Documentação (Tabela DocumentoPessoa) ---
        [Required(ErrorMessage = "A URL do documento CNPJ é obrigatória.")]
        [StringLength(500)]
        public string DocumentoCnpjUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "A URL do Contrato Social é obrigatória.")]
        [StringLength(500)]
        public string ContratoSocialUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "A URL da Logo da empresa é obrigatória.")]
        [StringLength(500)]
        public string LogoCnpjUrl { get; set; } = string.Empty;

        // =======================================================
        // --- 5. DADOS DO DRONE (NOVO: Tabela DronePiloto) ---
        // =======================================================
        [Required(ErrorMessage = "O modelo do drone é obrigatório.")]
        [StringLength(100)]
        public string ModeloDrone { get; set; } = string.Empty;

        [Required(ErrorMessage = "A marca do drone é obrigatória.")]
        [StringLength(100)]
        public string MarcaDrone { get; set; } = string.Empty;

        [Required(ErrorMessage = "O número de série do drone é obrigatório.")]
        [StringLength(100)]
        public string NumeroSerieDrone { get; set; } = string.Empty;

        [Required(ErrorMessage = "O número de homologação Anatel é obrigatório.")]
        [StringLength(100)]
        public string NumeroHomologacaoAnatel { get; set; } = string.Empty;

        [Required(ErrorMessage = "A URL da foto de homologação é obrigatória.")]
        [StringLength(500)]
        public string FotoHomologacaoAnatelUrl { get; set; } = string.Empty;

        // =======================================================
        // --- 6. DADOS DE CERTIFICAÇÃO (NOVO: Tabela CertificadosPiloto) ---
        // =======================================================
        [Required(ErrorMessage = "O número da Licença ANAC/CHPR é obrigatório.")]
        [StringLength(255)]
        public string NomeCertificado { get; set; } = string.Empty;

        [Required(ErrorMessage = "A categoria da licença é obrigatória.")]
        [StringLength(100)]
        public string CategoriaCertificado { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de validade do certificado é obrigatória.")]
        public DateTime ValidadeCertificado { get; set; }

        // =======================================================
        // --- 7. RELAÇÕES N:N (NOVO: IDs das tabelas auxiliares) ---
        // =======================================================
        [Required(ErrorMessage = "Selecione pelo menos uma especialidade.")]
        public List<int> IdsEspecialidade { get; set; } = new List<int>();

        [Required(ErrorMessage = "Selecione pelo menos um tipo de operação.")]
        public List<int> IdsTipoOperacao { get; set; } = new List<int>();
    }
}