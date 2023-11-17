using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auvo.RH.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Updatekey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TempoTrabalhado_Colaborador_ColaboradorCodigo",
                table: "TempoTrabalhado");

            migrationBuilder.RenameColumn(
                name: "ColaboradorCodigo",
                table: "TempoTrabalhado",
                newName: "PK_Colaborador");

            migrationBuilder.RenameIndex(
                name: "IX_TempoTrabalhado_ColaboradorCodigo",
                table: "TempoTrabalhado",
                newName: "IX_TempoTrabalhado_PK_Colaborador");

            migrationBuilder.AddForeignKey(
                name: "FK_TempoTrabalhado_Colaborador_PK_Colaborador",
                table: "TempoTrabalhado",
                column: "PK_Colaborador",
                principalTable: "Colaborador",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TempoTrabalhado_Colaborador_PK_Colaborador",
                table: "TempoTrabalhado");

            migrationBuilder.RenameColumn(
                name: "PK_Colaborador",
                table: "TempoTrabalhado",
                newName: "ColaboradorCodigo");

            migrationBuilder.RenameIndex(
                name: "IX_TempoTrabalhado_PK_Colaborador",
                table: "TempoTrabalhado",
                newName: "IX_TempoTrabalhado_ColaboradorCodigo");

            migrationBuilder.AddForeignKey(
                name: "FK_TempoTrabalhado_Colaborador_ColaboradorCodigo",
                table: "TempoTrabalhado",
                column: "ColaboradorCodigo",
                principalTable: "Colaborador",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
