using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroGeral.Migrations
{
    public partial class CriacaoVinculoUsuarioContato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Membros_MembroModelId",
                table: "Contatos");

            migrationBuilder.DropTable(
                name: "Membros");

            migrationBuilder.DropIndex(
                name: "IX_Contatos_MembroModelId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "MembroModelId",
                table: "Contatos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MembroModelId",
                table: "Contatos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Membros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataAtualizacaoCadastro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membros", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_MembroModelId",
                table: "Contatos",
                column: "MembroModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Membros_MembroModelId",
                table: "Contatos",
                column: "MembroModelId",
                principalTable: "Membros",
                principalColumn: "Id");
        }
    }
}
