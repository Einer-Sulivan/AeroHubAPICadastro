using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AeroHubAPI.Models
{
    [Table("Pessoa")]
    public class Pessoa
    {
        [Key]
        [Column("idPessoa")]
        public int IdPessoa { get; set; }

        [Column("idUsuario")]
        public int IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; } // Propriedade de Navegação

        [Required]
        [MaxLength(20)]
        [Column("tipoPessoa")] // 'CPF' ou 'CNPJ'
        public string TipoPessoa { get; set; } = string.Empty;

        [MaxLength(50)]
        [Column("contextoPessoa")] // 'Contratante' ou 'Piloto'
        public string? ContextoPessoa { get; set; }

        // --- Campos CPF ---
        [MaxLength(255)]
        [Column("nomeCompletoCpfPessoa")]
        public string? NomeCompletoCpfPessoa { get; set; }

        [MaxLength(14)]
        [Column("cpfCpfPessoa")]
        public string? CpfCpfPessoa { get; set; }

        [MaxLength(20)]
        [Column("rgCpfPessoa")]
        public string? RgCpfPessoa { get; set; }

        [Column("dataNascimentoCpfPessoa")]
        public DateTime? DataNascimentoCpfPessoa { get; set; }

        [MaxLength(20)]
        [Column("telefoneCpfPessoa")]
        public string? TelefoneCpfPessoa { get; set; }

        [MaxLength(20)]
        [Column("generoCpfPessoa")]
        public string? GeneroCpfPessoa { get; set; }

        // --- Campos CNPJ ---
        [MaxLength(255)]
        [Column("razaoSocialCnpjPessoa")]
        public string? RazaoSocialCnpjPessoa { get; set; }

        [MaxLength(255)]
        [Column("nomeFantasiaCnpjPessoa")]
        public string? NomeFantasiaCnpjPessoa { get; set; }

        [MaxLength(18)]
        [Column("cnpjCnpjPessoa")]
        public string? CnpjCnpjPessoa { get; set; }

        [MaxLength(50)]
        [Column("inscricaoEstadualCnpjPessoa")]
        public string? InscricaoEstadualCnpjPessoa { get; set; }

        [MaxLength(50)]
        [Column("inscricaoMunicipalCnpjPessoa")]
        public string? InscricaoMunicipalCnpjPessoa { get; set; }

        [MaxLength(50)]
        [Column("porteEmpresaCnpjPessoa")]
        public string? PorteEmpresaCnpjPessoa { get; set; }

        [Column("dataCriacaoPessoa")]
        public DateTime DataCriacaoPessoa { get; set; } = DateTime.Now;

        [Column("dataAtualizacaoPessoa")]
        public DateTime? DataAtualizacaoPessoa { get; set; }
    }
}