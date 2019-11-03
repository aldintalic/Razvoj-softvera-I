using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkExercise.Migrations
{
    public partial class D : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatumIspita",
                table: "upisaniPredmeti",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZakljucnaOcjena",
                table: "upisaniPredmeti",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatumIspita",
                table: "upisaniPredmeti");

            migrationBuilder.DropColumn(
                name: "ZakljucnaOcjena",
                table: "upisaniPredmeti");
        }
    }
}
