using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPD.Migrations
{
    /// <inheritdoc />
    public partial class _102 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeComunidade",
                table: "Projeto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeContribuinte",
                table: "Contribuicao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeComunidade",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "NomeContribuinte",
                table: "Contribuicao");
        }
    }
}
