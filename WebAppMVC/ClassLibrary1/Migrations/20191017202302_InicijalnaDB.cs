using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkExercise.Migrations
{
    public partial class InicijalnaDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fakulteti",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fakulteti", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "opstine",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_opstine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "studenti",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    FakultetID = table.Column<int>(nullable: true),
                    OpstinaRodjenjaID = table.Column<int>(nullable: true),
                    OpstinaPrebivalistaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studenti", x => x.ID);
                    table.ForeignKey(
                        name: "FK_studenti_fakulteti_FakultetID",
                        column: x => x.FakultetID,
                        principalTable: "fakulteti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_studenti_opstine_OpstinaPrebivalistaID",
                        column: x => x.OpstinaPrebivalistaID,
                        principalTable: "opstine",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_studenti_opstine_OpstinaRodjenjaID",
                        column: x => x.OpstinaRodjenjaID,
                        principalTable: "opstine",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studenti_FakultetID",
                table: "studenti",
                column: "FakultetID");

            migrationBuilder.CreateIndex(
                name: "IX_studenti_OpstinaPrebivalistaID",
                table: "studenti",
                column: "OpstinaPrebivalistaID");

            migrationBuilder.CreateIndex(
                name: "IX_studenti_OpstinaRodjenjaID",
                table: "studenti",
                column: "OpstinaRodjenjaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studenti");

            migrationBuilder.DropTable(
                name: "fakulteti");

            migrationBuilder.DropTable(
                name: "opstine");
        }
    }
}
