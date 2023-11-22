using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademiaWebApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Plano = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Exercicio",
                columns: table => new
                {
                    ExercicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MusculoAlvo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Equipamento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicio", x => x.ExercicioId);
                });

            migrationBuilder.CreateTable(
                name: "TreinoPersonalizado",
                columns: table => new
                {
                    TreinoPersonalizadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreinoPersonalizado", x => x.TreinoPersonalizadoId);
                    table.ForeignKey(
                        name: "FK_TreinoPersonalizado_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreinoPersonalizadoExercicio",
                columns: table => new
                {
                    TreinoPersonalizadoExercicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Series = table.Column<int>(type: "int", nullable: false),
                    Repeticoes = table.Column<int>(type: "int", nullable: false),
                    Carga = table.Column<int>(type: "int", nullable: false),
                    ExercicioId = table.Column<int>(type: "int", nullable: false),
                    TreinoPersonalizadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreinoPersonalizadoExercicio", x => x.TreinoPersonalizadoExercicioId);
                    table.ForeignKey(
                        name: "FK_TreinoPersonalizadoExercicio_Exercicio_ExercicioId",
                        column: x => x.ExercicioId,
                        principalTable: "Exercicio",
                        principalColumn: "ExercicioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreinoPersonalizadoExercicio_TreinoPersonalizado_TreinoPersonalizadoId",
                        column: x => x.TreinoPersonalizadoId,
                        principalTable: "TreinoPersonalizado",
                        principalColumn: "TreinoPersonalizadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreinoPersonalizado_ClienteId",
                table: "TreinoPersonalizado",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TreinoPersonalizadoExercicio_ExercicioId",
                table: "TreinoPersonalizadoExercicio",
                column: "ExercicioId");

            migrationBuilder.CreateIndex(
                name: "IX_TreinoPersonalizadoExercicio_TreinoPersonalizadoId",
                table: "TreinoPersonalizadoExercicio",
                column: "TreinoPersonalizadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreinoPersonalizadoExercicio");

            migrationBuilder.DropTable(
                name: "Exercicio");

            migrationBuilder.DropTable(
                name: "TreinoPersonalizado");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
