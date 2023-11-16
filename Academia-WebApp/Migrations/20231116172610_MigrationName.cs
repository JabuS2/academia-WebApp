using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademiaWebApp.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
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
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
                    TreinoPersonalizadoId = table.Column<int>(type: "int", nullable: false),
                    ExercicioId = table.Column<int>(type: "int", nullable: false),
                    Series = table.Column<int>(type: "int", nullable: false),
                    Repeticoes = table.Column<int>(type: "int", nullable: false),
                    Carga = table.Column<int>(type: "int", nullable: false),
                    ExercicioModelExercicioId = table.Column<int>(type: "int", nullable: true),
                    TreinoPersonalizadoModelTreinoPersonalizadoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreinoPersonalizadoExercicio", x => x.TreinoPersonalizadoExercicioId);
                    table.ForeignKey(
                        name: "FK_TreinoPersonalizadoExercicio_Exercicio_ExercicioModelExercicioId",
                        column: x => x.ExercicioModelExercicioId,
                        principalTable: "Exercicio",
                        principalColumn: "ExercicioId");
                    table.ForeignKey(
                        name: "FK_TreinoPersonalizadoExercicio_TreinoPersonalizado_TreinoPersonalizadoModelTreinoPersonalizadoId",
                        column: x => x.TreinoPersonalizadoModelTreinoPersonalizadoId,
                        principalTable: "TreinoPersonalizado",
                        principalColumn: "TreinoPersonalizadoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreinoPersonalizado_ClienteId",
                table: "TreinoPersonalizado",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TreinoPersonalizadoExercicio_ExercicioModelExercicioId",
                table: "TreinoPersonalizadoExercicio",
                column: "ExercicioModelExercicioId");

            migrationBuilder.CreateIndex(
                name: "IX_TreinoPersonalizadoExercicio_TreinoPersonalizadoModelTreinoPersonalizadoId",
                table: "TreinoPersonalizadoExercicio",
                column: "TreinoPersonalizadoModelTreinoPersonalizadoId");
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
