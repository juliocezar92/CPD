using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPD.Migrations
{
    /// <inheritdoc />
    public partial class _101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comunidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comunidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComunidadeId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoPessoa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoa_Comunidade_ComunidadeId",
                        column: x => x.ComunidadeId,
                        principalTable: "Comunidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComunidadeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorEstimado = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projeto_Comunidade_ComunidadeId",
                        column: x => x.ComunidadeId,
                        principalTable: "Comunidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contribuinte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    ValorContribuicao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Periodicidade = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PessoaResponsavelId = table.Column<int>(type: "int", nullable: false),
                    ProjetoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribuinte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contribuinte_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contribuinte_Pessoa_PessoaResponsavelId",
                        column: x => x.PessoaResponsavelId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contribuinte_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contribuicao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContribuinteId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorLiquido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataContribuicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoContribuicao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribuicao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contribuicao_Contribuinte_ContribuinteId",
                        column: x => x.ContribuinteId,
                        principalTable: "Contribuinte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contribuicao_ContribuinteId",
                table: "Contribuicao",
                column: "ContribuinteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contribuinte_PessoaId",
                table: "Contribuinte",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contribuinte_PessoaResponsavelId",
                table: "Contribuinte",
                column: "PessoaResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_Contribuinte_ProjetoId",
                table: "Contribuinte",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_ComunidadeId",
                table: "Pessoa",
                column: "ComunidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_ComunidadeId",
                table: "Projeto",
                column: "ComunidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contribuicao");

            migrationBuilder.DropTable(
                name: "Contribuinte");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Projeto");

            migrationBuilder.DropTable(
                name: "Comunidade");
        }
    }
}
