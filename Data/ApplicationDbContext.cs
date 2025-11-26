/*using AeroHubAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace AeroHubAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // =============================================
        // TABELAS PRINCIPAIS (DbSets)
        // =============================================
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Carteira> Carteiras { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<DocumentoPessoa> DocumentosPessoa { get; set; }
        public DbSet<RepresentanteLegalCnpjPessoa> RepresentantesLegal { get; set; }
        public DbSet<Contratante> Contratantes { get; set; }
        public DbSet<Piloto> Pilotos { get; set; }

        // --- Adicione as demais tabelas quando necessário ---
        // public DbSet<VerificacaoDocumentoPessoa> VerificacoesDocumentoPessoa { get; set; }
        // public DbSet<EstatisticaContratante> EstatisticasContratante { get; set; }
        // ... etc.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =============================================
            // CONFIGURAÇÕES DE ÍNDICES E CHAVES (Conforme seu DB)
            // =============================================

            // Tabela: Usuario (Índice único para o email)
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.EmailUsuario).IsUnique();
            });

            // Tabela: Carteira (idUsuario deve ser UNIQUE)
            modelBuilder.Entity<Carteira>(entity =>
            {
                entity.HasIndex(e => e.IdUsuario).IsUnique();
            });

            // Tabela: Pessoa (idUsuario deve ser UNIQUE, garantindo 1 perfil Pessoa por Usuario)
            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasIndex(e => e.IdUsuario).IsUnique();
                // Índice para buscas rápidas por CPF e CNPJ
                entity.HasIndex(e => e.CpfCpfPessoa).IsUnique().HasFilter("[cpfCpfPessoa] IS NOT NULL");
                entity.HasIndex(e => e.CnpjCnpjPessoa).IsUnique().HasFilter("[cnpjCnpjPessoa] IS NOT NULL");
            });

            // Tabela: RepresentanteLegalCnpjPessoa (1:1 com Pessoa)
            modelBuilder.Entity<RepresentanteLegalCnpjPessoa>(entity =>
            {
                entity.HasIndex(e => e.IdPessoa).IsUnique();
            });

            // Tabela: DocumentoPessoa (1:1 com Pessoa)
            modelBuilder.Entity<DocumentoPessoa>(entity =>
            {
                entity.HasIndex(e => e.IdPessoa).IsUnique();
            });

            // Tabela: Contratante (idUsuario e idPessoa devem ser UNIQUE)
            modelBuilder.Entity<Contratante>(entity =>
            {
                entity.HasIndex(e => e.IdUsuario).IsUnique();
                entity.HasIndex(e => e.IdPessoa).IsUnique();
            });

            // Tabela: Piloto (idUsuario e idPessoa devem ser UNIQUE)
            modelBuilder.Entity<Piloto>(entity =>
            {
                entity.HasIndex(e => e.IdUsuario).IsUnique();
                entity.HasIndex(e => e.IdPessoa).IsUnique();
            });
        }
    }
}*/

using AeroHubAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace AeroHubAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // =============================================
        // TABELAS PRINCIPAIS (DbSets)
        // =============================================
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Carteira> Carteiras { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<DocumentoPessoa> DocumentosPessoa { get; set; }
        public DbSet<RepresentanteLegalCnpjPessoa> RepresentantesLegal { get; set; }
        public DbSet<Contratante> Contratantes { get; set; }
        public DbSet<Piloto> Pilotos { get; set; }

        // --- NOVAS TABELAS DO FLUXO PILOTO ---
        public DbSet<DronePiloto> DronesPiloto { get; set; } // NOVO
        public DbSet<CertificadosPiloto> CertificadosPiloto { get; set; } // NOVO
        public DbSet<Especialidade> Especialidades { get; set; } // NOVO
        public DbSet<TipoOperacao> TiposOperacao { get; set; } // NOVO

        // --- NOVAS TABELAS N:N ---
        public DbSet<Piloto_Tem_Especialidade> PilotoTemEspecialidades { get; set; } // NOVO
        public DbSet<Piloto_Tem_TipoOperacao> PilotoTemTiposOperacao { get; set; } // NOVO

        // --- Adicione as demais tabelas que você criou, se faltar alguma ---
        // public DbSet<VerificacaoDocumentoPessoa> VerificacoesDocumentoPessoa { get; set; }
        // public DbSet<EstatisticaContratante> EstatisticasContratante { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =============================================
            // CONFIGURAÇÕES DE ÍNDICES E CHAVES
            // =============================================

            // Tabela: Usuario (Índice único para o email)
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.EmailUsuario).IsUnique();
            });

            // Tabela: Carteira (idUsuario deve ser UNIQUE)
            modelBuilder.Entity<Carteira>(entity =>
            {
                entity.HasIndex(e => e.IdUsuario).IsUnique();
            });

            // Tabela: Pessoa (Configurações de UNIQUE para idUsuario, CPF, CNPJ)
            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasIndex(e => e.IdUsuario).IsUnique();
                entity.HasIndex(e => e.CpfCpfPessoa).IsUnique().HasFilter("[cpfCpfPessoa] IS NOT NULL");
                entity.HasIndex(e => e.CnpjCnpjPessoa).IsUnique().HasFilter("[cnpjCnpjPessoa] IS NOT NULL");
            });

            // Tabela: RepresentanteLegalCnpjPessoa (1:1 com Pessoa)
            modelBuilder.Entity<RepresentanteLegalCnpjPessoa>(entity =>
            {
                entity.HasIndex(e => e.IdPessoa).IsUnique();
            });

            // Tabela: DocumentoPessoa (1:1 com Pessoa)
            modelBuilder.Entity<DocumentoPessoa>(entity =>
            {
                entity.HasIndex(e => e.IdPessoa).IsUnique();
            });

            // Tabela: Contratante (idUsuario e idPessoa devem ser UNIQUE)
            modelBuilder.Entity<Contratante>(entity =>
            {
                entity.HasIndex(e => e.IdUsuario).IsUnique();
                entity.HasIndex(e => e.IdPessoa).IsUnique();
            });

            // Tabela: Piloto (idUsuario e idPessoa devem ser UNIQUE)
            modelBuilder.Entity<Piloto>(entity =>
            {
                entity.HasIndex(e => e.IdUsuario).IsUnique();
                entity.HasIndex(e => e.IdPessoa).IsUnique();
            });

            // --- CONFIGURAÇÃO DAS CHAVES COMPOSTAS N:N (Piloto) ---

            // Tabela: Piloto_Tem_Especialidade
            modelBuilder.Entity<Piloto_Tem_Especialidade>()
                .HasKey(pte => new { pte.IdPiloto, pte.IdEspecialidade }); // Define a chave composta

            // Tabela: Piloto_Tem_TipoOperacao
            modelBuilder.Entity<Piloto_Tem_TipoOperacao>()
                .HasKey(ptto => new { ptto.IdPiloto, ptto.IdTipoOperacao }); // Define a chave composta
        }
    }
}