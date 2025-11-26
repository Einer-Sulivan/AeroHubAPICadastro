using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AeroHubAPI.Models
{
    [Table("DocumentoPessoa")]
    public class DocumentoPessoa
    {
        [Key]
        [Column("idDocumentoPessoa")]
        public int IdDocumentoPessoa { get; set; }

        [Column("idPessoa")]
        public int IdPessoa { get; set; }

        [ForeignKey(nameof(IdPessoa))]
        public Pessoa? Pessoa { get; set; } // Propriedade de Navegação

        [MaxLength(500)]
        [Column("fotoPerfilPessoaDocumentoPessoa")]
        public string? FotoPerfilPessoaDocumentoPessoa { get; set; }

        [MaxLength(500)]
        [Column("documentoFrenteCpfDocumentoPessoa")] // RG/CNH frente
        public string? DocumentoFrenteCpfDocumentoPessoa { get; set; }

        [MaxLength(500)]
        [Column("documentoVersoCpfDocumentoPessoa")] // RG/CNH verso
        public string? DocumentoVersoCpfDocumentoPessoa { get; set; }

        [MaxLength(500)]
        [Column("documentoCnpjDocumentoPessoa")] // Documento CNPJ
        public string? DocumentoCnpjDocumentoPessoa { get; set; }

        [MaxLength(500)]
        [Column("contratantoSocialCnpjDocumentoPessoa")] // Contrato Social
        public string? ContratantoSocialCnpjDocumentoPessoa { get; set; }

        [MaxLength(500)]
        [Column("logoCnpjDocumentoPessoa")]
        public string? LogoCnpjDocumentoPessoa { get; set; }
    }
}