using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PCWebShop.Migrations
{
    public partial class kreiranjeBaze : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banka",
                columns: table => new
                {
                    BankaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivBanke = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KontaktTel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banka", x => x.BankaID);
                });

            migrationBuilder.CreateTable(
                name: "Dostavljac",
                columns: table => new
                {
                    DostavljacID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivDostave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KontaktTelefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dostavljac", x => x.DostavljacID);
                });

            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    DrzavaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.DrzavaID);
                });

            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    KategorijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivKategorije = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.KategorijaID);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiNalog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lozinka = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodjac",
                columns: table => new
                {
                    ProizvodjacID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivProizvodjaca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrzavaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodjac", x => x.ProizvodjacID);
                    table.ForeignKey(
                        name: "FK_Proizvodjac_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DrzavaID = table.Column<int>(type: "int", nullable: false),
                    TrajanjeUgovora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Administrator_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Administrator_KorisnickiNalog_ID",
                        column: x => x.ID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AutentifikacijaToken",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vrijednost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnickiNalogId = table.Column<int>(type: "int", nullable: false),
                    vrijemeEvidentiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ipAdresa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutentifikacijaToken", x => x.id);
                    table.ForeignKey(
                        name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DrzavaID = table.Column<int>(type: "int", nullable: false),
                    LokacijaSlike = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Korisnik_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Korisnik_KorisnickiNalog_ID",
                        column: x => x.ID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    ProizvodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivProizvoda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cijena = table.Column<double>(type: "float", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    NaStanju = table.Column<int>(type: "int", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LokacijaSlike = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Snizen = table.Column<bool>(type: "bit", nullable: false),
                    KategorijaID = table.Column<int>(type: "int", nullable: false),
                    ProizvodjacID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.ProizvodID);
                    table.ForeignKey(
                        name: "FK_Proizvod_Kategorija_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorija",
                        principalColumn: "KategorijaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Proizvod_Proizvodjac_ProizvodjacID",
                        column: x => x.ProizvodjacID,
                        principalTable: "Proizvodjac",
                        principalColumn: "ProizvodjacID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Oglas",
                columns: table => new
                {
                    OglasID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojPozicja = table.Column<int>(type: "int", nullable: false),
                    Lokacija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumObjave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrajanjeOglasa = table.Column<int>(type: "int", nullable: false),
                    DatumIsteka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutorOglasaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oglas", x => x.OglasID);
                    table.ForeignKey(
                        name: "FK_Oglas_Administrator_AutorOglasaID",
                        column: x => x.AutorOglasaID,
                        principalTable: "Administrator",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutorPostaID = table.Column<int>(type: "int", nullable: false),
                    LokacijaSlike = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumObjave = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_Post_Administrator_AutorPostaID",
                        column: x => x.AutorPostaID,
                        principalTable: "Administrator",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    NarudzbaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NaruciocID = table.Column<int>(type: "int", nullable: false),
                    DostavljacID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.NarudzbaID);
                    table.ForeignKey(
                        name: "FK_Narudzba_Dostavljac_DostavljacID",
                        column: x => x.DostavljacID,
                        principalTable: "Dostavljac",
                        principalColumn: "DostavljacID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Narudzba_Korisnik_NaruciocID",
                        column: x => x.NaruciocID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Racun",
                columns: table => new
                {
                    BankovniRacunID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojRacuna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumAktiviranjaRacuna = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StanjeRacuna = table.Column<double>(type: "float", nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    BankaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racun", x => x.BankovniRacunID);
                    table.ForeignKey(
                        name: "FK_Racun_Banka_BankaID",
                        column: x => x.BankaID,
                        principalTable: "Banka",
                        principalColumn: "BankaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Racun_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Recenzija",
                columns: table => new
                {
                    RecenzijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocjena = table.Column<int>(type: "int", nullable: false),
                    Komentar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProizvodID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzija", x => x.RecenzijaID);
                    table.ForeignKey(
                        name: "FK_Recenzija_Proizvod_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvod",
                        principalColumn: "ProizvodID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikOglas",
                columns: table => new
                {
                    KorisnikOglasID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    OglasID = table.Column<int>(type: "int", nullable: false),
                    DatumPrijave = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikOglas", x => x.KorisnikOglasID);
                    table.ForeignKey(
                        name: "FK_KorisnikOglas_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KorisnikOglas_Oglas_OglasID",
                        column: x => x.OglasID,
                        principalTable: "Oglas",
                        principalColumn: "OglasID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "NarudzbaStavka",
                columns: table => new
                {
                    NarudzbaStavkaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    Cijena = table.Column<double>(type: "float", nullable: false),
                    ProizvodID = table.Column<int>(type: "int", nullable: false),
                    NarudzbaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarudzbaStavka", x => x.NarudzbaStavkaID);
                    table.ForeignKey(
                        name: "FK_NarudzbaStavka_Narudzba_NarudzbaID",
                        column: x => x.NarudzbaID,
                        principalTable: "Narudzba",
                        principalColumn: "NarudzbaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_NarudzbaStavka_Proizvod_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvod",
                        principalColumn: "ProizvodID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_DrzavaID",
                table: "Administrator",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_AutentifikacijaToken_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_DrzavaID",
                table: "Korisnik",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikOglas_KorisnikID",
                table: "KorisnikOglas",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikOglas_OglasID",
                table: "KorisnikOglas",
                column: "OglasID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_DostavljacID",
                table: "Narudzba",
                column: "DostavljacID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_NaruciocID",
                table: "Narudzba",
                column: "NaruciocID");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavka_NarudzbaID",
                table: "NarudzbaStavka",
                column: "NarudzbaID");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavka_ProizvodID",
                table: "NarudzbaStavka",
                column: "ProizvodID");

            migrationBuilder.CreateIndex(
                name: "IX_Oglas_AutorOglasaID",
                table: "Oglas",
                column: "AutorOglasaID");

            migrationBuilder.CreateIndex(
                name: "IX_Post_AutorPostaID",
                table: "Post",
                column: "AutorPostaID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_KategorijaID",
                table: "Proizvod",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_ProizvodjacID",
                table: "Proizvod",
                column: "ProizvodjacID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodjac_DrzavaID",
                table: "Proizvodjac",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_BankaID",
                table: "Racun",
                column: "BankaID");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_KorisnikID",
                table: "Racun",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzija_ProizvodID",
                table: "Recenzija",
                column: "ProizvodID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutentifikacijaToken");

            migrationBuilder.DropTable(
                name: "KorisnikOglas");

            migrationBuilder.DropTable(
                name: "NarudzbaStavka");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Racun");

            migrationBuilder.DropTable(
                name: "Recenzija");

            migrationBuilder.DropTable(
                name: "Oglas");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "Banka");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "Dostavljac");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Kategorija");

            migrationBuilder.DropTable(
                name: "Proizvodjac");

            migrationBuilder.DropTable(
                name: "KorisnickiNalog");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
