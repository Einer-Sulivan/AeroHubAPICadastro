using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AeroHubAPI.Models
{
    [Table("RepresentanteLegalCnpjPessoa")]
    public class RepresentanteLegalCnpjPessoa
    {
        [Key]
        [Column("idRepresentanteLegal")]
        public int IdRepresentanteLegal { get; set; }

        [Column("idPessoa")]
        public int IdPessoa { get; set; }

        [ForeignKey(nameof(IdPessoa))]
        public Pessoa? Pessoa { get; set; } // Propriedade de Navegação

        [MaxLength(255)]
        [Column("nomeRepresentanteLegalCnpjPessoa")]
        public string? NomeRepresentanteLegalCnpjPessoa { get; set; }

        [MaxLength(14)]
        [Column("cpfRepresentanteLegalCnpjPessoa")]
        public string? CpfRepresentanteLegalCnpjPessoa { get; set; }

        [MaxLength(100)]
        [Column("cargoRepresentanteLegalCnpjPessoa")]
        public string? CargoRepresentanteLegalCnpjPessoa { get; set; }

        [MaxLength(255)]
        [Column("emailRepresentanteLegalCnpjPessoa")]
        public string? EmailRepresentanteLegalCnpjPessoa { get; set; }

        [MaxLength(20)]
        [Column("telefoneRepresentanteLegalCnpjPessoa")]
        public string? TelefoneRepresentanteLegalCnpjPessoa { get; set; }
    }
}