using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_Ispit_20170621_v1.Migrations
{
    public partial class ispravka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaturskiIspitStavka_UpisUOdjeljenje_UpisUOdjeljenjeId",
                table: "MaturskiIspitStavka");

            migrationBuilder.DropColumn(
                name: "UspisUOdjeljenjeId",
                table: "MaturskiIspitStavka");

            migrationBuilder.AlterColumn<int>(
                name: "UpisUOdjeljenjeId",
                table: "MaturskiIspitStavka",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MaturskiIspitStavka_UpisUOdjeljenje_UpisUOdjeljenjeId",
                table: "MaturskiIspitStavka",
                column: "UpisUOdjeljenjeId",
                principalTable: "UpisUOdjeljenje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaturskiIspitStavka_UpisUOdjeljenje_UpisUOdjeljenjeId",
                table: "MaturskiIspitStavka");

            migrationBuilder.AlterColumn<int>(
                name: "UpisUOdjeljenjeId",
                table: "MaturskiIspitStavka",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UspisUOdjeljenjeId",
                table: "MaturskiIspitStavka",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_MaturskiIspitStavka_UpisUOdjeljenje_UpisUOdjeljenjeId",
                table: "MaturskiIspitStavka",
                column: "UpisUOdjeljenjeId",
                principalTable: "UpisUOdjeljenje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
