using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_Ispit_asp.net_core.Migrations
{
    public partial class ispravkaBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "OpravdanoOdsutan",
                table: "OdrzanCasDetalj",
                nullable: true,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "OpravdanoOdsutan",
                table: "OdrzanCasDetalj",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
