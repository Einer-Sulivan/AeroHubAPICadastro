using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AeroHubAPI.Models
{
    [Table("Piloto_Tem_TipoOperacao")]
    public class Piloto_Tem_TipoOperacao
    {
        [Column("idPiloto")]
        public int IdPiloto { get; set; }

        [Column("idTipoOperacao")]
        public int IdTipoOperacao { get; set; }

        [Column("dataCriacao")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [ForeignKey(nameof(IdPiloto))]
        public Piloto? Piloto { get; set; }

        [ForeignKey(nameof(IdTipoOperacao))]
        public TipoOperacao? TipoOperacao { get; set; }
    }
}