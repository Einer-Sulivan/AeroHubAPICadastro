using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AeroHubAPI.Models
{
    [Table("DronePiloto")]
    public class DronePiloto
    {
        [Key]
        [Column("idDronePiloto")]
        public int IdDronePiloto { get; set; }

        [Column("idPiloto")]
        public int IdPiloto { get; set; }

        [ForeignKey(nameof(IdPiloto))]
        public Piloto? Piloto { get; set; } // Propriedade de Navegação

        [MaxLength(100)]
        [Column("marcaDronePiloto")]
        public string? MarcaDronePiloto { get; set; }

        [MaxLength(100)]
        [Column("modeloDronePiloto")]
        public string? ModeloDronePiloto { get; set; }

        [MaxLength(100)]
        [Column("numeroSerieDronePiloto")]
        public string? NumeroSerieDronePiloto { get; set; }

        [MaxLength(100)]
        [Column("numeroHomologacaoAnatelDronePiloto")]
        public string? NumeroHomologacaoAnatelDronePiloto { get; set; }

        [MaxLength(500)]
        [Column("fotoHomologacaoAnatelDronePiloto")]
        public string? FotoHomologacaoAnatelDronePiloto { get; set; } // URL do documento de homologação

        [Column("anatelVerificadaDronePiloto")]
        public bool AnatelVerificadaDronePiloto { get; set; } = false;
    }
}