using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auvo.RH.DAL.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartamentoCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Colaborador_Departamento_DepartamentoCodigo",
                        column: x => x.DepartamentoCodigo,
                        principalTable: "Departamento",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TempoTrabalhado",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorHora = table.Column<float>(type: "real", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Entrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Saida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlmocoInic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlmocoFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ColaboradorCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempoTrabalhado", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_TempoTrabalhado_Colaborador_ColaboradorCodigo",
                        column: x => x.ColaboradorCodigo,
                        principalTable: "Colaborador",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_DepartamentoCodigo",
                table: "Colaborador",
                column: "DepartamentoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_TempoTrabalhado_ColaboradorCodigo",
                table: "TempoTrabalhado",
                column: "ColaboradorCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TempoTrabalhado");

            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropTable(
                name: "Departamento");
        }
    }
}
