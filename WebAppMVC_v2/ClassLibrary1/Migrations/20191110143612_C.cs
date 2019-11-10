using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibrary1.Migrations
{
    public partial class C : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fakulteti_univerziteti_UniverzitetID",
                table: "fakulteti");

            migrationBuilder.DropColumn(
                name: "UnvierzitetID",
                table: "fakulteti");

            migrationBuilder.AlterColumn<int>(
                name: "UniverzitetID",
                table: "fakulteti",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_fakulteti_univerziteti_UniverzitetID",
                table: "fakulteti",
                column: "UniverzitetID",
                principalTable: "univerziteti",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fakulteti_univerziteti_UniverzitetID",
                table: "fakulteti");

            migrationBuilder.AlterColumn<int>(
                name: "UniverzitetID",
                table: "fakulteti",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UnvierzitetID",
                table: "fakulteti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_fakulteti_univerziteti_UniverzitetID",
                table: "fakulteti",
                column: "UniverzitetID",
                principalTable: "univerziteti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
