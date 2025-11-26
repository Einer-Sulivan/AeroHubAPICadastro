using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AeroHubAPI.Models
{
    [Table("Especialidade")]
    public class Especialidade
    {
        [Key]
        [Column("idEspecialidade")]
        public int IdEspecialidade { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("nomeEspecialidade")]
        public string NomeEspecialidade { get; set; } = string.Empty;
    }
}