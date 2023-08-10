using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPD.Migrations
{
    /// <inheritdoc />
    public partial class Atualizacao102 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Contribuicao_ContribuicaoId",
                table: "Pessoa");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_ContribuicaoId",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "ContribuicaoId",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "DataFim",
                table: "Contribuicao");

            migrationBuilder.DropColumn(
                name: "DataInicio",
                table: "Contribuicao");

            migrationBuilder.RenameColumn(
                name: "PessoaId",
                table: "Contribuicao",
                newName: "ContribuinteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contribuicao_ContribuinteId",
                table: "Contribuicao",
                column: "ContribuinteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contribuicao_Contribuinte_ContribuinteId",
                table: "Contribuicao",
                column: "ContribuinteId",
                principalTable: "Contribuinte",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contribuicao_Contribuinte_ContribuinteId",
                table: "Contribuicao");

            migrationBuilder.DropIndex(
                name: "IX_Contribuicao_ContribuinteId",
                table: "Contribuicao");

            migrationBuilder.RenameColumn(
                name: "ContribuinteId",
                table: "Contribuicao",
                newName: "PessoaId");

            migrationBuilder.AddColumn<int>(
                name: "ContribuicaoId",
                table: "Pessoa",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFim",
                table: "Contribuicao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInicio",
                table: "Contribuicao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_ContribuicaoId",
                table: "Pessoa",
                column: "ContribuicaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Contribuicao_ContribuicaoId",
                table: "Pessoa",
                column: "ContribuicaoId",
                principalTable: "Contribuicao",
                principalColumn: "Id");
        }
    }
}
