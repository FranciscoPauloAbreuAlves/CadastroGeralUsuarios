using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroGeral.Migrations
{
    public partial class CriandoVinculoMembroContato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "Contatos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "MembroModelId",
                table: "Contatos",
                type: "int",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Membros_MembroModelId",
                table: "Contatos");

            migrationBuilder.DropIndex(
                name: "IX_Contatos_MembroModelId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "MembroModelId",
                table: "Contatos");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "Contatos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
