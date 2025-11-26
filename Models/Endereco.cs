using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AeroHubAPI.Models
{
    [Table("Endereco")]
    public class Endereco
    {
        [Key]
        [Column("idEndereco")]
        public int IdEndereco { get; set; }

        [Column("idPessoa")]
        public int IdPessoa { get; set; }

        [ForeignKey(nameof(IdPessoa))]
        public Pessoa? Pessoa { get; set; } // Propriedade de Navegação

        [Required]
        [MaxLength(10)]
        [Column("cepEndereco")]
        public string CepEndereco { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column("logradouroEndereco")]
        public string LogradouroEndereco { get; set; } = string.Empty;

        [MaxLength(20)]
        [Column("numeroEndereco")]
        public string? NumeroEndereco { get; set; }

        [MaxLength(255)]
        [Column("complementoEndereco")]
        public string? ComplementoEndereco { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("bairroEndereco")]
        public string BairroEndereco { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [Column("cidadeEndereco")]
        public string CidadeEndereco { get; set; } = string.Empty;

        [Required]
        [MaxLength(2)]
        [Column("estadoEndereco")]
        public string EstadoEndereco { get; set; } = string.Empty;

        [Column("dataCriacaoEndereco")]
        public DateTime DataCriacaoEndereco { get; set; } = DateTime.Now;
    }
}