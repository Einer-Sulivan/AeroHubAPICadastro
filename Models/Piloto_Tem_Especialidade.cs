using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AeroHubAPI.Models
{
    [Table("Piloto_Tem_Especialidade")]
    public class Piloto_Tem_Especialidade
    {
        [Column("idPiloto")]
        public int IdPiloto { get; set; }

        [Column("idEspecialidade")]
        public int IdEspecialidade { get; set; }

        [Column("dataCriacao")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [ForeignKey(nameof(IdPiloto))]
        public Piloto? Piloto { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }
    }
}