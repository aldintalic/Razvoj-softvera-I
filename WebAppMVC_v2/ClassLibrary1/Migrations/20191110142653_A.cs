using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibrary1.Migrations
{
    public partial class A : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "predmeti",
                columns: table => new
                {
                    PredmetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    ects = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_predmeti", x => x.PredmetID);
                });

            migrationBuilder.CreateTable(
                name: "Univerzitet",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Univerzitet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "fakulteti",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    UnvierzitetID = table.Column<int>(nullable: false),
                    UniverzitetID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fakulteti", x => x.ID);
                    table.ForeignKey(
                        name: "FK_fakulteti_Univerzitet_UniverzitetID",
                        column: x => x.UniverzitetID,
                        principalTable: "Univerzitet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                    FakultetID = table.Column<int>(nullable: false),
                    OpstinaRodjenjaID = table.Column<int>(nullable: false),
                    OpstinaPrebivalistaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studenti", x => x.ID);
                    table.ForeignKey(
                        name: "FK_studenti_fakulteti_FakultetID",
                        column: x => x.FakultetID,
                        principalTable: "fakulteti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_studenti_opstine_OpstinaPrebivalistaID",
                        column: x => x.OpstinaPrebivalistaID,
                        principalTable: "opstine",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_studenti_opstine_OpstinaRodjenjaID",
                        column: x => x.OpstinaRodjenjaID,
                        principalTable: "opstine",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "upisiGodina",
                columns: table => new
                {
                    UpisGodineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GodinaStudija = table.Column<int>(nullable: false),
                    DatumUpisa = table.Column<DateTime>(nullable: false),
                    JelObnova = table.Column<bool>(nullable: false),
                    StudentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_upisiGodina", x => x.UpisGodineID);
                    table.ForeignKey(
                        name: "FK_upisiGodina_studenti_StudentID",
                        column: x => x.StudentID,
                        principalTable: "studenti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "upisaniPredmeti",
                columns: table => new
                {
                    UpisaniPredmetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZakljucnaOcjena = table.Column<int>(nullable: true),
                    DatumIspita = table.Column<DateTime>(nullable: true),
                    PredmetID = table.Column<int>(nullable: false),
                    UpisGodineID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_upisaniPredmeti", x => x.UpisaniPredmetID);
                    table.ForeignKey(
                        name: "FK_upisaniPredmeti_predmeti_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "predmeti",
                        principalColumn: "PredmetID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_upisaniPredmeti_upisiGodina_UpisGodineID",
                        column: x => x.UpisGodineID,
                        principalTable: "upisiGodina",
                        principalColumn: "UpisGodineID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fakulteti_UniverzitetID",
                table: "fakulteti",
                column: "UniverzitetID");

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

            migrationBuilder.CreateIndex(
                name: "IX_upisaniPredmeti_PredmetID",
                table: "upisaniPredmeti",
                column: "PredmetID");

            migrationBuilder.CreateIndex(
                name: "IX_upisaniPredmeti_UpisGodineID",
                table: "upisaniPredmeti",
                column: "UpisGodineID");

            migrationBuilder.CreateIndex(
                name: "IX_upisiGodina_StudentID",
                table: "upisiGodina",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "upisaniPredmeti");

            migrationBuilder.DropTable(
                name: "predmeti");

            migrationBuilder.DropTable(
                name: "upisiGodina");

            migrationBuilder.DropTable(
                name: "studenti");

            migrationBuilder.DropTable(
                name: "fakulteti");

            migrationBuilder.DropTable(
                name: "opstine");

            migrationBuilder.DropTable(
                name: "Univerzitet");
        }
    }
}
