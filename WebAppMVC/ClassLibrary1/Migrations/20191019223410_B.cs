using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkExercise.Migrations
{
    public partial class B : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studenti_fakulteti_FakultetID",
                table: "studenti");

            migrationBuilder.DropForeignKey(
                name: "FK_studenti_opstine_OpstinaPrebivalistaID",
                table: "studenti");

            migrationBuilder.DropForeignKey(
                name: "FK_studenti_opstine_OpstinaRodjenjaID",
                table: "studenti");

            migrationBuilder.AlterColumn<int>(
                name: "OpstinaRodjenjaID",
                table: "studenti",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OpstinaPrebivalistaID",
                table: "studenti",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FakultetID",
                table: "studenti",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_studenti_fakulteti_FakultetID",
                table: "studenti",
                column: "FakultetID",
                principalTable: "fakulteti",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_studenti_opstine_OpstinaPrebivalistaID",
                table: "studenti",
                column: "OpstinaPrebivalistaID",
                principalTable: "opstine",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_studenti_opstine_OpstinaRodjenjaID",
                table: "studenti",
                column: "OpstinaRodjenjaID",
                principalTable: "opstine",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studenti_fakulteti_FakultetID",
                table: "studenti");

            migrationBuilder.DropForeignKey(
                name: "FK_studenti_opstine_OpstinaPrebivalistaID",
                table: "studenti");

            migrationBuilder.DropForeignKey(
                name: "FK_studenti_opstine_OpstinaRodjenjaID",
                table: "studenti");

            migrationBuilder.AlterColumn<int>(
                name: "OpstinaRodjenjaID",
                table: "studenti",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "OpstinaPrebivalistaID",
                table: "studenti",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FakultetID",
                table: "studenti",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_studenti_fakulteti_FakultetID",
                table: "studenti",
                column: "FakultetID",
                principalTable: "fakulteti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_studenti_opstine_OpstinaPrebivalistaID",
                table: "studenti",
                column: "OpstinaPrebivalistaID",
                principalTable: "opstine",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_studenti_opstine_OpstinaRodjenjaID",
                table: "studenti",
                column: "OpstinaRodjenjaID",
                principalTable: "opstine",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
