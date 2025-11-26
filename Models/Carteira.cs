using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AeroHubAPI.Models
{
    [Table("Carteira")]
    public class Carteira
    {
        [Key]
        [Column("idCarteira")]
        public int IdCarteira { get; set; }

        [Column("idUsuario")]
        public int IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        [Column("saldoPilotoCarteira", TypeName = "DECIMAL(15,2)")]
        public decimal SaldoPilotoCarteira { get; set; } = 0;

        [Column("saldoContratanteCarteira", TypeName = "DECIMAL(15,2)")]
        public decimal SaldoContratanteCarteira { get; set; } = 0;

        [Column("saldoBloqueadoCarteira", TypeName = "DECIMAL(15,2)")]
        public decimal SaldoBloqueadoCarteira { get; set; } = 0;

        [Column("totalRecebidoPilotoCarteira", TypeName = "DECIMAL(15,2)")]
        public decimal TotalRecebidoPilotoCarteira { get; set; } = 0;

        [Column("totalSacadoPilotoCarteira", TypeName = "DECIMAL(15,2)")]
        public decimal TotalSacadoPilotoCarteira { get; set; } = 0;

        [Column("totalGastoContratanteCarteira", TypeName = "DECIMAL(15,2)")]
        public decimal TotalGastoContratanteCarteira { get; set; } = 0;

        [Column("pendenteReceberCarteira", TypeName = "DECIMAL(15,2)")]
        public decimal PendenteReceberCarteira { get; set; } = 0;

        [Column("valorMinimoSaqueCarteira", TypeName = "DECIMAL(15,2)")]
        public decimal ValorMinimoSaqueCarteira { get; set; } = 50.00m; // Usando 'm' para decimal

        [Column("dataCriacaoCarteira")]
        public DateTime DataCriacaoCarteira { get; set; } = DateTime.Now;
    }
}