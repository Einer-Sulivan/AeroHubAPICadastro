using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AeroHubAPI.Models
{
    [Table("TipoOperacao")]
    public class TipoOperacao
    {
        [Key]
        [Column("idTipoOperacao")]
        public int IdTipoOperacao { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("nomeTipoOperacao")]
        public string NomeTipoOperacao { get; set; } = string.Empty;
    }
}