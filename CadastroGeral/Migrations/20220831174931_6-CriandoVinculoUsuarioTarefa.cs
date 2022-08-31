using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroGeral.Migrations
{
    public partial class _6CriandoVinculoUsuarioTarefa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioModelId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_UsuarioModelId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "UsuarioModelId",
                table: "Tarefas");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_UsuarioId",
                table: "Tarefas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioId",
                table: "Tarefas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_UsuarioId",
                table: "Tarefas");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioModelId",
                table: "Tarefas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_UsuarioModelId",
                table: "Tarefas",
                column: "UsuarioModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioModelId",
                table: "Tarefas",
                column: "UsuarioModelId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
