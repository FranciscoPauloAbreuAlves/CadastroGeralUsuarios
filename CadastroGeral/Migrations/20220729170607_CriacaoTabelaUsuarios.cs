//using System;
//using CadastroGeral.Enums;
//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace CadastroGeral.Migrations
//{
//    public partial class CriacaoTabelaUsuarios : Migration
//    {
//        protected override void Up(MigrationBuilder migrationBuilder) => migrationBuilder.CreateTable(
//                name: "Usuarios",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    Perfil = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    Senha = table.Column<PerfilEnum>(type: "nvarchar(max)", nullable: false),
//                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
//                    DataAtualizacaoCadastro = table.Column<DateTime>(type: "datetime2", nullable: true)

//                },

//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Usuarios", x => x.Id);
//                });

//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "Usuarios");
//        }
//    }
//}
