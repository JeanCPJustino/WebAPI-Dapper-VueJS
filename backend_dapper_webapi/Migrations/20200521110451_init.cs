using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend_dapper_webapi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    id_professor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.id_professor);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    id_aluno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true),
                    sobrenome = table.Column<string>(nullable: true),
                    dataNascimento = table.Column<DateTime>(nullable: false),
                    id_professor = table.Column<int>(nullable: false),
                    Professorid_professor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.id_aluno);
                    table.ForeignKey(
                        name: "FK_Alunos_Professores_Professorid_professor",
                        column: x => x.Professorid_professor,
                        principalTable: "Professores",
                        principalColumn: "id_professor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "id_aluno", "Professorid_professor", "dataNascimento", "id_professor", "nome", "sobrenome" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1987, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mazinho", "Messi Black" },
                    { 2, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Patrick", "Barriga de Cavalo" },
                    { 3, null, new DateTime(1993, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Deyverson", "Cambalhota" },
                    { 4, null, new DateTime(1992, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Alceu", "Voadora" },
                    { 5, null, new DateTime(1987, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Miguel", "Borja" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "id_professor", "nome" },
                values: new object[,]
                {
                    { 1, "César" },
                    { 2, "Ademir" },
                    { 3, "Edmundo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_Professorid_professor",
                table: "Alunos",
                column: "Professorid_professor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
