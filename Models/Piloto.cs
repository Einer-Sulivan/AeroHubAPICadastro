using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AeroHubAPI.Models
{
    [Table("Piloto")]
    public class Piloto
    {
        [Key]
        [Column("idPiloto")]
        public int IdPiloto { get; set; }

        [Column("idUsuario")]
        public int IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; } // Propriedade de Navegação

        [Column("idPessoa")]
        public int IdPessoa { get; set; }

        [ForeignKey(nameof(IdPessoa))]
        public Pessoa? Pessoa { get; set; } // Propriedade de Navegação

        [MaxLength(255)]
        [Column("tituloProfissionalPiloto")]
        public string? TituloProfissionalPiloto { get; set; }

        [Column("sobreMimPiloto", TypeName = "TEXT")]
        public string? SobreMimPiloto { get; set; }

        [Column("planoPremiumAtivadoPiloto")]
        public bool PlanoPremiumAtivadoPiloto { get; set; } = false;

        [Column("planoPremiumDesdePiloto")]
        public DateTime? PlanoPremiumDesdePiloto { get; set; }

        [MaxLength(50)]
        [Column("statusContaPiloto")]
        public string? StatusContaPiloto { get; set; }

        [Column("dataCriacaoPiloto")]
        public DateTime DataCriacaoPiloto { get; set; } = DateTime.Now;
    }
}