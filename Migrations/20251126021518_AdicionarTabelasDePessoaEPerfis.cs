using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AeroHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarTabelasDePessoaEPerfis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emailUsuario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    senhaUsuario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    tipoCadastroUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    dataCriacaoControleUsuario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    termosAceitosUsuario = table.Column<bool>(type: "bit", nullable: false),
                    dataAceiteTermosUsuario = table.Column<DateTime>(type: "datetime2", nullable: true),
                    statusContaUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Carteira",
                columns: table => new
                {
                    idCarteira = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    saldoPilotoCarteira = table.Column<decimal>(type: "DECIMAL(15,2)", nullable: false),
                    saldoContratanteCarteira = table.Column<decimal>(type: "DECIMAL(15,2)", nullable: false),
                    saldoBloqueadoCarteira = table.Column<decimal>(type: "DECIMAL(15,2)", nullable: false),
                    totalRecebidoPilotoCarteira = table.Column<decimal>(type: "DECIMAL(15,2)", nullable: false),
                    totalSacadoPilotoCarteira = table.Column<decimal>(type: "DECIMAL(15,2)", nullable: false),
                    totalGastoContratanteCarteira = table.Column<decimal>(type: "DECIMAL(15,2)", nullable: false),
                    pendenteReceberCarteira = table.Column<decimal>(type: "DECIMAL(15,2)", nullable: false),
                    valorMinimoSaqueCarteira = table.Column<decimal>(type: "DECIMAL(15,2)", nullable: false),
                    dataCriacaoCarteira = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carteira", x => x.idCarteira);
                    table.ForeignKey(
                        name: "FK_Carteira_Usuario_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    idPessoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    tipoPessoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    contextoPessoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nomeCompletoCpfPessoa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    cpfCpfPessoa = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    rgCpfPessoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    dataNascimentoCpfPessoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    telefoneCpfPessoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    generoCpfPessoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    razaoSocialCnpjPessoa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    nomeFantasiaCnpjPessoa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    cnpjCnpjPessoa = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    inscricaoEstadualCnpjPessoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    inscricaoMunicipalCnpjPessoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    porteEmpresaCnpjPessoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    dataCriacaoPessoa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAtualizacaoPessoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.idPessoa);
                    table.ForeignKey(
                        name: "FK_Pessoa_Usuario_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contratante",
                columns: table => new
                {
                    idContratante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    idPessoa = table.Column<int>(type: "int", nullable: false),
                    tituloProfissionalContratante = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dataCriacaoContratante = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sobreMimContratante = table.Column<string>(type: "TEXT", nullable: true),
                    setorAtuacaoContratante = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    perfilCompletoContratante = table.Column<bool>(type: "bit", nullable: false),
                    percentualConclusaoPerfilContratante = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: true),
                    statusContaContratante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    dataAtualizacaoContratante = table.Column<DateTime>(type: "datetime2", nullable: true),
                    planoPremiumAtivadoContratante = table.Column<bool>(type: "bit", nullable: false),
                    premimDesdeContratante = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratante", x => x.idContratante);
                    table.ForeignKey(
                        name: "FK_Contratante_Pessoa_idPessoa",
                        column: x => x.idPessoa,
                        principalTable: "Pessoa",
                        principalColumn: "idPessoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratante_Usuario_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentoPessoa",
                columns: table => new
                {
                    idDocumentoPessoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPessoa = table.Column<int>(type: "int", nullable: false),
                    fotoPerfilPessoaDocumentoPessoa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    documentoFrenteCpfDocumentoPessoa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    documentoVersoCpfDocumentoPessoa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    documentoCnpjDocumentoPessoa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    contratantoSocialCnpjDocumentoPessoa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    logoCnpjDocumentoPessoa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoPessoa", x => x.idDocumentoPessoa);
                    table.ForeignKey(
                        name: "FK_DocumentoPessoa_Pessoa_idPessoa",
                        column: x => x.idPessoa,
                        principalTable: "Pessoa",
                        principalColumn: "idPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    idEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPessoa = table.Column<int>(type: "int", nullable: false),
                    cepEndereco = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    logradouroEndereco = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    numeroEndereco = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    complementoEndereco = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    bairroEndereco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cidadeEndereco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    estadoEndereco = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    dataCriacaoEndereco = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.idEndereco);
                    table.ForeignKey(
                        name: "FK_Endereco_Pessoa_idPessoa",
                        column: x => x.idPessoa,
                        principalTable: "Pessoa",
                        principalColumn: "idPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Piloto",
                columns: table => new
                {
                    idPiloto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    idPessoa = table.Column<int>(type: "int", nullable: false),
                    tituloProfissionalPiloto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    sobreMimPiloto = table.Column<string>(type: "TEXT", nullable: true),
                    planoPremiumAtivadoPiloto = table.Column<bool>(type: "bit", nullable: false),
                    planoPremiumDesdePiloto = table.Column<DateTime>(type: "datetime2", nullable: true),
                    statusContaPiloto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    dataCriacaoPiloto = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piloto", x => x.idPiloto);
                    table.ForeignKey(
                        name: "FK_Piloto_Pessoa_idPessoa",
                        column: x => x.idPessoa,
                        principalTable: "Pessoa",
                        principalColumn: "idPessoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Piloto_Usuario_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepresentanteLegalCnpjPessoa",
                columns: table => new
                {
                    idRepresentanteLegal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPessoa = table.Column<int>(type: "int", nullable: false),
                    nomeRepresentanteLegalCnpjPessoa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    cpfRepresentanteLegalCnpjPessoa = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    cargoRepresentanteLegalCnpjPessoa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    emailRepresentanteLegalCnpjPessoa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    telefoneRepresentanteLegalCnpjPessoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepresentanteLegalCnpjPessoa", x => x.idRepresentanteLegal);
                    table.ForeignKey(
                        name: "FK_RepresentanteLegalCnpjPessoa_Pessoa_idPessoa",
                        column: x => x.idPessoa,
                        principalTable: "Pessoa",
                        principalColumn: "idPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carteira_idUsuario",
                table: "Carteira",
                column: "idUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contratante_idPessoa",
                table: "Contratante",
                column: "idPessoa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contratante_idUsuario",
                table: "Contratante",
                column: "idUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoPessoa_idPessoa",
                table: "DocumentoPessoa",
                column: "idPessoa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_idPessoa",
                table: "Endereco",
                column: "idPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_cnpjCnpjPessoa",
                table: "Pessoa",
                column: "cnpjCnpjPessoa",
                unique: true,
                filter: "[cnpjCnpjPessoa] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_cpfCpfPessoa",
                table: "Pessoa",
                column: "cpfCpfPessoa",
                unique: true,
                filter: "[cpfCpfPessoa] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_idUsuario",
                table: "Pessoa",
                column: "idUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Piloto_idPessoa",
                table: "Piloto",
                column: "idPessoa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Piloto_idUsuario",
                table: "Piloto",
                column: "idUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepresentanteLegalCnpjPessoa_idPessoa",
                table: "RepresentanteLegalCnpjPessoa",
                column: "idPessoa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_emailUsuario",
                table: "Usuario",
                column: "emailUsuario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carteira");

            migrationBuilder.DropTable(
                name: "Contratante");

            migrationBuilder.DropTable(
                name: "DocumentoPessoa");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Piloto");

            migrationBuilder.DropTable(
                name: "RepresentanteLegalCnpjPessoa");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
