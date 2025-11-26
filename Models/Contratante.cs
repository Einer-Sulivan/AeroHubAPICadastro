using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AeroHubAPI.Models
{
    [Table("Contratante")]
    public class Contratante
    {
        [Key]
        [Column("idContratante")]
        public int IdContratante { get; set; }

        [Column("idUsuario")]
        public int IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; } // Propriedade de Navegação

        [Column("idPessoa")]
        public int IdPessoa { get; set; }

        [ForeignKey(nameof(IdPessoa))]
        public Pessoa? Pessoa { get; set; } // Propriedade de Navegação

        [MaxLength(255)]
        [Column("tituloProfissionalContratante")]
        public string? TituloProfissionalContratante { get; set; }

        [Column("dataCriacaoContratante")]
        public DateTime DataCriacaoContratante { get; set; } = DateTime.Now;

        [Column("sobreMimContratante", TypeName = "TEXT")]
        public string? SobreMimContratante { get; set; }

        [MaxLength(100)]
        [Column("setorAtuacaoContratante")]
        public string? SetorAtuacaoContratante { get; set; }

        [Column("perfilCompletoContratante")]
        public bool PerfilCompletoContratante { get; set; } = false;

        [Column("percentualConclusaoPerfilContratante", TypeName = "DECIMAL(5,2)")]
        public decimal? PercentualConclusaoPerfilContratante { get; set; }

        [MaxLength(50)]
        [Column("statusContaContratante")]
        public string? StatusContaContratante { get; set; }

        [Column("dataAtualizacaoContratante")]
        public DateTime? DataAtualizacaoContratante { get; set; }

        [Column("planoPremiumAtivadoContratante")]
        public bool PlanoPremiumAtivadoContratante { get; set; } = false;

        [Column("premimDesdeContratante")]
        public DateTime? PremiumDesdeContratante { get; set; }
    }
}