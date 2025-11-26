using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AeroHubAPI.Models
{
    [Table("CertificadosPiloto")]
    public class CertificadosPiloto
    {
        [Key]
        [Column("idCertificacaoPiloto")]
        public int IdCertificacaoPiloto { get; set; }

        [Column("idPiloto")]
        public int IdPiloto { get; set; }

        [ForeignKey(nameof(IdPiloto))]
        public Piloto? Piloto { get; set; } // Propriedade de Navegação

        [MaxLength(50)]
        [Column("codigoCredencialCertificadoPiloto")] // numero da Licença ANAC
        public string? codigoCredencialCertificadoPilotoo { get; set; }

        [MaxLength(100)]
        [Column("categoriaCertificadoPiloto")] // Categoria da Licença ANAC
        public string? CategoriaCertificadoPiloto { get; set; }

        [Column("validadeCertificadoPiloto")]
        public DateTime? ValidadeCertificadoPiloto { get; set; } // Data de Validade

        [MaxLength(255)]
        [Column("nomeCertificadoPiloto")] // Nome da Licença ANAC (CHPR)
        public string? NomeCertificadoPiloto { get; set; }

        [MaxLength(500)]
        [Column("uploadCertificadoPiloto")] // URL do upload da licença
        public string? UploadCertificadoPiloto { get; set; }

        [Column("certificadoVerificadaPiloto")]
        public bool CertificadoVerificadaPiloto { get; set; } = false;

        [Column("dataVerificacaoCertificadoPiloto")]
        public DateTime? DataVerificacaoCertificadoPiloto { get; set; }
    }
}