using AeroHubAPI.Data;
using AeroHubAPI.DTOs;
using AeroHubAPI.Models;
using AeroHubAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AeroHubAPI.Services
{
    public class CadastroService : ICadastroService
    {
        private readonly ApplicationDbContext _context;

        public CadastroService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método auxiliar para validação de existência do Usuário e evitar duplicidade de perfil
        private async Task ValidarUsuarioEPerfilExistente(int idUsuario)
        {
            var usuario = await _context.Usuarios.FindAsync(idUsuario);
            if (usuario == null)
            {
                throw new KeyNotFoundException($"Usuário com ID {idUsuario} não encontrado.");
            }

            // Verifica se o Usuário já tem um perfil Pessoa (evita que o mesmo usuário seja cliente e piloto ao mesmo tempo)
            var pessoaExistente = await _context.Pessoas.AnyAsync(p => p.IdUsuario == idUsuario);
            if (pessoaExistente)
            {
                throw new InvalidOperationException("Este usuário já possui um perfil de Pessoa cadastrado (CPF ou CNPJ).");
            }
        }

        // ====================================================
        // FLUXO DE CLIENTE (CONTRATANTE)
        // ====================================================

        // ----------------------------------------------------
        // CLIENTE (CPF) - PESSOA FÍSICA
        // ----------------------------------------------------
        public async Task<Pessoa> CadastrarClienteCpfAsync(ClienteCpfCadastroDto dto)
        {
            await ValidarUsuarioEPerfilExistente(dto.IdUsuario);

            // Inicia uma transação (garante que todas as operações são salvas ou desfeitas juntas)
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // 1. Criar Pessoa
                var pessoa = new Pessoa
                {
                    IdUsuario = dto.IdUsuario,
                    TipoPessoa = "CPF",
                    ContextoPessoa = "Contratante",
                    NomeCompletoCpfPessoa = dto.NomeCompleto,
                    CpfCpfPessoa = dto.Cpf,
                    TelefoneCpfPessoa = dto.Telefone,
                    GeneroCpfPessoa = dto.Genero,
                    DataNascimentoCpfPessoa = dto.DataNascimento,
                    DataAtualizacaoPessoa = DateTime.Now
                };
                _context.Pessoas.Add(pessoa);
                await _context.SaveChangesAsync(); // Salva para obter o IdPessoa

                // 2. Criar Endereco
                var endereco = new Endereco
                {
                    IdPessoa = pessoa.IdPessoa,
                    CepEndereco = dto.Cep,
                    LogradouroEndereco = dto.Logradouro,
                    NumeroEndereco = dto.Numero,
                    ComplementoEndereco = dto.Complemento,
                    BairroEndereco = dto.Bairro,
                    CidadeEndereco = dto.Cidade,
                    EstadoEndereco = dto.Estado
                };
                _context.Enderecos.Add(endereco);

                // 3. Criar DocumentoPessoa
                var documento = new DocumentoPessoa
                {
                    IdPessoa = pessoa.IdPessoa,
                    DocumentoFrenteCpfDocumentoPessoa = dto.DocumentoFrenteUrl,
                    DocumentoVersoCpfDocumentoPessoa = dto.DocumentoVersoUrl,
                    FotoPerfilPessoaDocumentoPessoa = dto.FotoPerfilUrl
                };
                _context.DocumentosPessoa.Add(documento);

                // 4. Criar Contratante
                var contratante = new Contratante
                {
                    IdUsuario = dto.IdUsuario,
                    IdPessoa = pessoa.IdPessoa,
                    StatusContaContratante = "Pendente Verificação",
                    DataCriacaoContratante = DateTime.Now
                };
                _context.Contratantes.Add(contratante);

                // 5. Atualizar tipoCadastro do Usuario (Cliente)
                var usuario = await _context.Usuarios.FindAsync(dto.IdUsuario);
                if (usuario != null)
                {
                    usuario.TipoCadastroUsuario = "Cliente";
                }

                await _context.SaveChangesAsync();

                await transaction.CommitAsync(); // Confirma a transação

                return pessoa;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(); // Desfaz tudo em caso de erro
                throw;
            }
        }

        // ----------------------------------------------------
        // CLIENTE (CNPJ) - PESSOA JURÍDICA
        // ----------------------------------------------------
        public async Task<Pessoa> CadastrarClienteCnpjAsync(ClienteCnpjCadastroDto dto)
        {
            await ValidarUsuarioEPerfilExistente(dto.IdUsuario);

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // 1. Criar Pessoa (CNPJ)
                var pessoa = new Pessoa
                {
                    IdUsuario = dto.IdUsuario,
                    TipoPessoa = "CNPJ",
                    ContextoPessoa = "Contratante",
                    RazaoSocialCnpjPessoa = dto.RazaoSocial,
                    NomeFantasiaCnpjPessoa = dto.NomeFantasia,
                    CnpjCnpjPessoa = dto.Cnpj,
                    InscricaoEstadualCnpjPessoa = dto.InscricaoEstadual,
                    InscricaoMunicipalCnpjPessoa = dto.InscricaoMunicipal,
                    PorteEmpresaCnpjPessoa = dto.PorteEmpresa,
                    DataAtualizacaoPessoa = DateTime.Now
                };
                _context.Pessoas.Add(pessoa);
                await _context.SaveChangesAsync();

                // 2. Criar Representante Legal
                var representante = new RepresentanteLegalCnpjPessoa
                {
                    IdPessoa = pessoa.IdPessoa,
                    NomeRepresentanteLegalCnpjPessoa = dto.NomeRepresentante,
                    CpfRepresentanteLegalCnpjPessoa = dto.CpfRepresentante,
                    CargoRepresentanteLegalCnpjPessoa = dto.CargoRepresentante,
                    EmailRepresentanteLegalCnpjPessoa = dto.EmailRepresentante,
                    TelefoneRepresentanteLegalCnpjPessoa = dto.TelefoneRepresentante
                };
                _context.RepresentantesLegal.Add(representante);

                // 3. Criar Endereco
                var endereco = new Endereco
                {
                    IdPessoa = pessoa.IdPessoa,
                    CepEndereco = dto.Cep,
                    LogradouroEndereco = dto.Logradouro,
                    NumeroEndereco = dto.Numero,
                    ComplementoEndereco = dto.Complemento,
                    BairroEndereco = dto.Bairro,
                    CidadeEndereco = dto.Cidade,
                    EstadoEndereco = dto.Estado
                };
                _context.Enderecos.Add(endereco);

                // 4. Criar DocumentoPessoa (CNPJ, Contrato Social, Logo)
                var documento = new DocumentoPessoa
                {
                    IdPessoa = pessoa.IdPessoa,
                    DocumentoCnpjDocumentoPessoa = dto.DocumentoCnpjUrl,
                    ContratantoSocialCnpjDocumentoPessoa = dto.ContratoSocialUrl,
                    LogoCnpjDocumentoPessoa = dto.LogoCnpjUrl
                };
                _context.DocumentosPessoa.Add(documento);

                // 5. Criar Contratante
                var contratante = new Contratante
                {
                    IdUsuario = dto.IdUsuario,
                    IdPessoa = pessoa.IdPessoa,
                    StatusContaContratante = "Pendente Verificação",
                    DataCriacaoContratante = DateTime.Now
                };
                _context.Contratantes.Add(contratante);

                // 6. Atualizar tipoCadastro do Usuario (Cliente)
                var usuario = await _context.Usuarios.FindAsync(dto.IdUsuario);
                if (usuario != null)
                {
                    usuario.TipoCadastroUsuario = "Cliente";
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return pessoa;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        // ====================================================
        // FLUXO DE PILOTO
        // ====================================================

        // ----------------------------------------------------
        // PILOTO (CPF) - PESSOA FÍSICA
        // ----------------------------------------------------
        public async Task<Pessoa> CadastrarPilotoCpfAsync(PilotoCpfCadastroDto dto)
        {
            await ValidarUsuarioEPerfilExistente(dto.IdUsuario);

            // Certifica-se que o usuário inicial escolheu "Piloto" (Regra de Negócio)
            var usuario = await _context.Usuarios.FindAsync(dto.IdUsuario);
            if (usuario == null || usuario.TipoCadastroUsuario != "Piloto")
            {
                throw new InvalidOperationException("O cadastro inicial deve ser para 'Piloto' para usar este endpoint.");
            }

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // 1. Criar Pessoa
                var pessoa = new Pessoa
                {
                    IdUsuario = dto.IdUsuario,
                    TipoPessoa = "CPF",
                    ContextoPessoa = "Piloto",
                    NomeCompletoCpfPessoa = dto.NomeCompleto,
                    CpfCpfPessoa = dto.Cpf,
                    RgCpfPessoa = dto.Rg,
                    TelefoneCpfPessoa = dto.Telefone,
                    GeneroCpfPessoa = dto.Genero,
                    DataNascimentoCpfPessoa = dto.DataNascimento,
                    DataAtualizacaoPessoa = DateTime.Now
                };
                _context.Pessoas.Add(pessoa);
                await _context.SaveChangesAsync();

                // 2. Criar Endereco
                var endereco = new Endereco
                {
                    IdPessoa = pessoa.IdPessoa,
                    CepEndereco = dto.Cep,
                    LogradouroEndereco = dto.Logradouro,
                    NumeroEndereco = dto.Numero,
                    ComplementoEndereco = dto.Complemento,
                    BairroEndereco = dto.Bairro,
                    CidadeEndereco = dto.Cidade,
                    EstadoEndereco = dto.Estado
                };
                _context.Enderecos.Add(endereco);

                // 3. Criar DocumentoPessoa
                var documento = new DocumentoPessoa
                {
                    IdPessoa = pessoa.IdPessoa,
                    DocumentoFrenteCpfDocumentoPessoa = dto.DocumentoFrenteUrl,
                    DocumentoVersoCpfDocumentoPessoa = dto.DocumentoVersoUrl,
                    FotoPerfilPessoaDocumentoPessoa = dto.FotoPerfilUrl
                };
                _context.DocumentosPessoa.Add(documento);

                // 4. Criar Piloto
                var piloto = new Piloto
                {
                    IdUsuario = dto.IdUsuario,
                    IdPessoa = pessoa.IdPessoa,
                    TituloProfissionalPiloto = dto.TituloProfissional,
                    StatusContaPiloto = "Pendente Verificação",
                    DataCriacaoPiloto = DateTime.Now
                };
                _context.Pilotos.Add(piloto);

                // 5. Atualizar tipoCadastro do Usuario
                if (usuario != null)
                {
                    usuario.TipoCadastroUsuario = "Piloto"; // Já é Piloto, mas garante a consistência
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return pessoa;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        // ----------------------------------------------------
        // PILOTO (CNPJ) - PESSOA JURÍDICA
        // ----------------------------------------------------
        public async Task<Pessoa> CadastrarPilotoCnpjAsync(PilotoCnpjCadastroDto dto)
        {
            await ValidarUsuarioEPerfilExistente(dto.IdUsuario);

            // Certifica-se que o usuário inicial escolheu "Piloto"
            var usuario = await _context.Usuarios.FindAsync(dto.IdUsuario);
            if (usuario == null || usuario.TipoCadastroUsuario != "Piloto")
            {
                throw new InvalidOperationException("O cadastro inicial deve ser para 'Piloto' para usar este endpoint.");
            }

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // 1. Criar Pessoa (CNPJ)
                var pessoa = new Pessoa
                {
                    IdUsuario = dto.IdUsuario,
                    TipoPessoa = "CNPJ",
                    ContextoPessoa = "Piloto",
                    RazaoSocialCnpjPessoa = dto.RazaoSocial,
                    NomeFantasiaCnpjPessoa = dto.NomeFantasia,
                    CnpjCnpjPessoa = dto.Cnpj,
                    InscricaoEstadualCnpjPessoa = dto.InscricaoEstadual,
                    InscricaoMunicipalCnpjPessoa = dto.InscricaoMunicipal,
                    PorteEmpresaCnpjPessoa = dto.PorteEmpresa,
                    DataAtualizacaoPessoa = DateTime.Now
                };
                _context.Pessoas.Add(pessoa);
                await _context.SaveChangesAsync();

                // 2. Criar Representante Legal
                var representante = new RepresentanteLegalCnpjPessoa
                {
                    IdPessoa = pessoa.IdPessoa,
                    NomeRepresentanteLegalCnpjPessoa = dto.NomeRepresentante,
                    CpfRepresentanteLegalCnpjPessoa = dto.CpfRepresentante,
                    CargoRepresentanteLegalCnpjPessoa = dto.CargoRepresentante,
                    EmailRepresentanteLegalCnpjPessoa = dto.EmailRepresentante,
                    TelefoneRepresentanteLegalCnpjPessoa = dto.TelefoneRepresentante
                };
                _context.RepresentantesLegal.Add(representante);

                // 3. Criar Endereco
                var endereco = new Endereco
                {
                    IdPessoa = pessoa.IdPessoa,
                    CepEndereco = dto.Cep,
                    LogradouroEndereco = dto.Logradouro,
                    NumeroEndereco = dto.Numero,
                    ComplementoEndereco = dto.Complemento,
                    BairroEndereco = dto.Bairro,
                    CidadeEndereco = dto.Cidade,
                    EstadoEndereco = dto.Estado
                };
                _context.Enderecos.Add(endereco);

                // 4. Criar DocumentoPessoa (CNPJ, Contrato Social, Logo)
                var documento = new DocumentoPessoa
                {
                    IdPessoa = pessoa.IdPessoa,
                    DocumentoCnpjDocumentoPessoa = dto.DocumentoCnpjUrl,
                    ContratantoSocialCnpjDocumentoPessoa = dto.ContratoSocialUrl,
                    LogoCnpjDocumentoPessoa = dto.LogoCnpjUrl
                };
                _context.DocumentosPessoa.Add(documento);

                // 5. Criar Piloto
                var piloto = new Piloto
                {
                    IdUsuario = dto.IdUsuario,
                    IdPessoa = pessoa.IdPessoa,
                    TituloProfissionalPiloto = dto.TituloProfissional,
                    StatusContaPiloto = "Pendente Verificação",
                    DataCriacaoPiloto = DateTime.Now
                };
                _context.Pilotos.Add(piloto);

                // 6. Atualizar tipoCadastro do Usuario
                if (usuario != null)
                {
                    usuario.TipoCadastroUsuario = "Piloto"; // Garante consistência
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return pessoa;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}