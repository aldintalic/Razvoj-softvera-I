using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibrary1.Migrations
{
    public partial class B : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fakulteti_Univerzitet_UniverzitetID",
                table: "fakulteti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Univerzitet",
                table: "Univerzitet");

            migrationBuilder.RenameTable(
                name: "Univerzitet",
                newName: "univerziteti");

            migrationBuilder.AddPrimaryKey(
                name: "PK_univerziteti",
                table: "univerziteti",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_fakulteti_univerziteti_UniverzitetID",
                table: "fakulteti",
                column: "UniverzitetID",
                principalTable: "univerziteti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fakulteti_univerziteti_UniverzitetID",
                table: "fakulteti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_univerziteti",
                table: "univerziteti");

            migrationBuilder.RenameTable(
                name: "univerziteti",
                newName: "Univerzitet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Univerzitet",
                table: "Univerzitet",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_fakulteti_Univerzitet_UniverzitetID",
                table: "fakulteti",
                column: "UniverzitetID",
                principalTable: "Univerzitet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
