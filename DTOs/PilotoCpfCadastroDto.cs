using System.ComponentModel.DataAnnotations;

namespace AeroHubAPI.DTOs
{
    // DTO ÚNICO para o cadastro Piloto PF (Pessoa Física)
    public class PilotoCpfCadastroDto
    {
        // 1. Chave de Identificação
        [Required(ErrorMessage = "O ID do Usuário é obrigatório.")]
        public int IdUsuario { get; set; }

        // --- 2. Dados Pessoais (Tabela Pessoa) ---
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [StringLength(255)]
        public string NomeCompleto { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(14)]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Rg é obrigatório.")]
        [StringLength(20)]
        public string? Rg { get; set; } // RG

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [StringLength(20)]
        public string Telefone { get; set; } = string.Empty;

        [Required(ErrorMessage = "O gênero é obrigatório.")]
        [StringLength(20)]
        public string Genero { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }

        // --- 3. Endereço (Tabela Endereco) ---
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

        // --- 4. Documentação (Tabela DocumentoPessoa) ---
        [Required(ErrorMessage = "A URL da foto da frente do documento é obrigatória.")]
        [StringLength(500)]
        public string DocumentoFrenteUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "A URL da foto do verso do documento é obrigatória.")]
        [StringLength(500)]
        public string DocumentoVersoUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "A URL da foto de perfil é obrigatória.")]
        [StringLength(500)]
        public string FotoPerfilUrl { get; set; } = string.Empty;

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
        //[Required(ErrorMessage = "Selecione pelo menos uma especialidade.")]
        public List<int> IdsEspecialidade { get; set; } = new List<int>();

        //[Required(ErrorMessage = "Selecione pelo menos um tipo de operação.")]
        public List<int> IdsTipoOperacao { get; set; } = new List<int>();
    }
}