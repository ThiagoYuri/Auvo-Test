using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auvo.RH.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTempoTrabalhado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlmocoFim",
                table: "TempoTrabalhado");

            migrationBuilder.DropColumn(
                name: "AlmocoInic",
                table: "TempoTrabalhado");

            migrationBuilder.AddColumn<string>(
                name: "Almoco",
                table: "TempoTrabalhado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Almoco",
                table: "TempoTrabalhado");

            migrationBuilder.AddColumn<DateTime>(
                name: "AlmocoFim",
                table: "TempoTrabalhado",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AlmocoInic",
                table: "TempoTrabalhado",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
