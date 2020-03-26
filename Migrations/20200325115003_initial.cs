using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace optomŠifrarnik.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PodstavkaSifrarnika",
                columns: table => new
                {
                    PodstavkaSifrarnikaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Oznaka = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Naziv = table.Column<string>(nullable: false),
                    Preduzece = table.Column<string>(nullable: false),
                    RedniBroj = table.Column<int>(nullable: false),
                    DatumKreiranja = table.Column<DateTime>(nullable: false),
                    StavkaSifrarnikaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodstavkaSifrarnika", x => x.PodstavkaSifrarnikaId);
                });

            migrationBuilder.CreateTable(
                name: "Sifrarnik",
                columns: table => new
                {
                    SifrarnikId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Oznaka = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Naziv = table.Column<string>(nullable: false),
                    Opis = table.Column<string>(nullable: false),
                    Programerski = table.Column<bool>(nullable: false),
                    Kesiranje = table.Column<bool>(nullable: false),
                    DatumKreiranja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sifrarnik", x => x.SifrarnikId);
                });

            migrationBuilder.CreateTable(
                name: "StavkaSifrarnika",
                columns: table => new
                {
                    StavkaSifrarnikaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Oznaka = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Naziv = table.Column<string>(nullable: false),
                    Preduzece = table.Column<string>(nullable: false),
                    RedniBroj = table.Column<int>(nullable: false),
                    DatumKreiranja = table.Column<DateTime>(nullable: false),
                    SifrarnikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaSifrarnika", x => x.StavkaSifrarnikaId);
                });

            migrationBuilder.InsertData(
                table: "PodstavkaSifrarnika",
                columns: new[] { "PodstavkaSifrarnikaId", "DatumKreiranja", "Naziv", "Oznaka", "Preduzece", "RedniBroj", "StavkaSifrarnikaId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 3, 25, 12, 50, 3, 620, DateTimeKind.Local), "Vozilo parkirano na nepropisno mjesto...", "NEPRAVILNO_PARKIRANJE", "RAD", 0, 2 },
                    { 2, new DateTime(2020, 3, 25, 12, 50, 3, 620, DateTimeKind.Local), "Potreban pauz za odvoz vozila", "PAUK_ZA_ODVOZ_VOZILA", "RAD", 0, 1 },
                    { 3, new DateTime(2020, 3, 25, 12, 50, 3, 620, DateTimeKind.Local), "Potreban pauz za odvoz vozila", "PAUK_ZA_ODVOZ_VOZILA_1", "RAD", 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Sifrarnik",
                columns: new[] { "SifrarnikId", "DatumKreiranja", "Kesiranje", "Naziv", "Opis", "Oznaka", "Programerski" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 3, 25, 12, 50, 3, 615, DateTimeKind.Local), false, "Problemi tokom izvršavanja", "Da li je prilikom izvršavanja...", "IZVRSENJE_PROBLEMI", false },
                    { 2, new DateTime(2020, 3, 25, 12, 50, 3, 619, DateTimeKind.Local), true, "Kvalifikacija zalbi", "Stablo za klasificiranje...", "Kvalifikacija-ZALBE", true }
                });

            migrationBuilder.InsertData(
                table: "StavkaSifrarnika",
                columns: new[] { "StavkaSifrarnikaId", "DatumKreiranja", "Naziv", "Oznaka", "Preduzece", "RedniBroj", "SifrarnikId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 3, 25, 12, 50, 3, 620, DateTimeKind.Local), "Sa vodom i otpadnim vodama", "VODA", "KJKP Vodovod i kanali", 0, 2 },
                    { 2, new DateTime(2020, 3, 25, 12, 50, 3, 620, DateTimeKind.Local), "Sa parkingom", "PARKING", "RAD", 1, 2 },
                    { 3, new DateTime(2020, 3, 25, 12, 50, 3, 620, DateTimeKind.Local), "Sa vodom i otpadnim vodama", "VODA", "KJKP Vodovod i kanali", 0, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PodstavkaSifrarnika");

            migrationBuilder.DropTable(
                name: "Sifrarnik");

            migrationBuilder.DropTable(
                name: "StavkaSifrarnika");
        }
    }
}
