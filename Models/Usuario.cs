using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AeroHubAPI.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [Column("idUsuario")]
        public int IdUsuario { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("emailUsuario")]
        public string EmailUsuario { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column("senhaUsuario")]
        public string SenhaUsuario { get; set; } = string.Empty;

        [MaxLength(50)]
        [Column("tipoCadastroUsuario")]
        public string? TipoCadastroUsuario { get; set; }

        [Column("dataCriacaoControleUsuario")]
        public DateTime DataCriacaoControleUsuario { get; set; } = DateTime.Now;

        [Column("termosAceitosUsuario")]
        public bool TermosAceitosUsuario { get; set; } = false;

        [Column("dataAceiteTermosUsuario")]
        public DateTime? DataAceiteTermosUsuario { get; set; }

        [MaxLength(50)]
        [Column("statusContaUsuario")]
        public string StatusContaUsuario { get; set; } = "Ativa";
    }
}