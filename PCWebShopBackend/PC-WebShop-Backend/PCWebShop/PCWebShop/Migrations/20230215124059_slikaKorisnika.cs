using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PCWebShop.Migrations
{
    public partial class slikaKorisnika : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administrator_Drzava_DrzavaID",
                table: "Administrator");

            migrationBuilder.DropForeignKey(
                name: "FK_Administrator_KorisnickiNalog_ID",
                table: "Administrator");

            migrationBuilder.DropForeignKey(
                name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                table: "AutentifikacijaToken");

            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_Drzava_DrzavaID",
                table: "Korisnik");

            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_KorisnickiNalog_ID",
                table: "Korisnik");

            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikOglas_Korisnik_KorisnikID",
                table: "KorisnikOglas");

            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikOglas_Oglas_OglasID",
                table: "KorisnikOglas");

            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Dostavljac_DostavljacID",
                table: "Narudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Korisnik_NaruciocID",
                table: "Narudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_NarudzbaStavka_Narudzba_NarudzbaID",
                table: "NarudzbaStavka");

            migrationBuilder.DropForeignKey(
                name: "FK_NarudzbaStavka_Proizvod_ProizvodID",
                table: "NarudzbaStavka");

            migrationBuilder.DropForeignKey(
                name: "FK_Oglas_Administrator_AutorOglasaID",
                table: "Oglas");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Administrator_AutorPostaID",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_Kategorija_KategorijaID",
                table: "Proizvod");

            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_Proizvodjac_ProizvodjacID",
                table: "Proizvod");

            migrationBuilder.DropForeignKey(
                name: "FK_Proizvodjac_Drzava_DrzavaID",
                table: "Proizvodjac");

            migrationBuilder.DropForeignKey(
                name: "FK_Racun_Banka_BankaID",
                table: "Racun");

            migrationBuilder.DropForeignKey(
                name: "FK_Racun_Korisnik_KorisnikID",
                table: "Racun");

            migrationBuilder.DropForeignKey(
                name: "FK_Recenzija_Proizvod_ProizvodID",
                table: "Recenzija");

            migrationBuilder.RenameColumn(
                name: "LokacijaSlike",
                table: "Korisnik",
                newName: "slika_korisnika");

            migrationBuilder.AddColumn<byte[]>(
                name: "slika_korisnika_bytes",
                table: "Korisnik",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Administrator_Drzava_DrzavaID",
                table: "Administrator",
                column: "DrzavaID",
                principalTable: "Drzava",
                principalColumn: "DrzavaID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Administrator_KorisnickiNalog_ID",
                table: "Administrator",
                column: "ID",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "KorisnickiNalogId",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_Drzava_DrzavaID",
                table: "Korisnik",
                column: "DrzavaID",
                principalTable: "Drzava",
                principalColumn: "DrzavaID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_KorisnickiNalog_ID",
                table: "Korisnik",
                column: "ID",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnikOglas_Korisnik_KorisnikID",
                table: "KorisnikOglas",
                column: "KorisnikID",
                principalTable: "Korisnik",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnikOglas_Oglas_OglasID",
                table: "KorisnikOglas",
                column: "OglasID",
                principalTable: "Oglas",
                principalColumn: "OglasID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Dostavljac_DostavljacID",
                table: "Narudzba",
                column: "DostavljacID",
                principalTable: "Dostavljac",
                principalColumn: "DostavljacID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Korisnik_NaruciocID",
                table: "Narudzba",
                column: "NaruciocID",
                principalTable: "Korisnik",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_NarudzbaStavka_Narudzba_NarudzbaID",
                table: "NarudzbaStavka",
                column: "NarudzbaID",
                principalTable: "Narudzba",
                principalColumn: "NarudzbaID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_NarudzbaStavka_Proizvod_ProizvodID",
                table: "NarudzbaStavka",
                column: "ProizvodID",
                principalTable: "Proizvod",
                principalColumn: "ProizvodID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Oglas_Administrator_AutorOglasaID",
                table: "Oglas",
                column: "AutorOglasaID",
                principalTable: "Administrator",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Administrator_AutorPostaID",
                table: "Post",
                column: "AutorPostaID",
                principalTable: "Administrator",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvod_Kategorija_KategorijaID",
                table: "Proizvod",
                column: "KategorijaID",
                principalTable: "Kategorija",
                principalColumn: "KategorijaID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvod_Proizvodjac_ProizvodjacID",
                table: "Proizvod",
                column: "ProizvodjacID",
                principalTable: "Proizvodjac",
                principalColumn: "ProizvodjacID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvodjac_Drzava_DrzavaID",
                table: "Proizvodjac",
                column: "DrzavaID",
                principalTable: "Drzava",
                principalColumn: "DrzavaID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Racun_Banka_BankaID",
                table: "Racun",
                column: "BankaID",
                principalTable: "Banka",
                principalColumn: "BankaID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Racun_Korisnik_KorisnikID",
                table: "Racun",
                column: "KorisnikID",
                principalTable: "Korisnik",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Recenzija_Proizvod_ProizvodID",
                table: "Recenzija",
                column: "ProizvodID",
                principalTable: "Proizvod",
                principalColumn: "ProizvodID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administrator_Drzava_DrzavaID",
                table: "Administrator");

            migrationBuilder.DropForeignKey(
                name: "FK_Administrator_KorisnickiNalog_ID",
                table: "Administrator");

            migrationBuilder.DropForeignKey(
                name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                table: "AutentifikacijaToken");

            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_Drzava_DrzavaID",
                table: "Korisnik");

            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_KorisnickiNalog_ID",
                table: "Korisnik");

            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikOglas_Korisnik_KorisnikID",
                table: "KorisnikOglas");

            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikOglas_Oglas_OglasID",
                table: "KorisnikOglas");

            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Dostavljac_DostavljacID",
                table: "Narudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Korisnik_NaruciocID",
                table: "Narudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_NarudzbaStavka_Narudzba_NarudzbaID",
                table: "NarudzbaStavka");

            migrationBuilder.DropForeignKey(
                name: "FK_NarudzbaStavka_Proizvod_ProizvodID",
                table: "NarudzbaStavka");

            migrationBuilder.DropForeignKey(
                name: "FK_Oglas_Administrator_AutorOglasaID",
                table: "Oglas");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Administrator_AutorPostaID",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_Kategorija_KategorijaID",
                table: "Proizvod");

            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_Proizvodjac_ProizvodjacID",
                table: "Proizvod");

            migrationBuilder.DropForeignKey(
                name: "FK_Proizvodjac_Drzava_DrzavaID",
                table: "Proizvodjac");

            migrationBuilder.DropForeignKey(
                name: "FK_Racun_Banka_BankaID",
                table: "Racun");

            migrationBuilder.DropForeignKey(
                name: "FK_Racun_Korisnik_KorisnikID",
                table: "Racun");

            migrationBuilder.DropForeignKey(
                name: "FK_Recenzija_Proizvod_ProizvodID",
                table: "Recenzija");

            migrationBuilder.DropColumn(
                name: "slika_korisnika_bytes",
                table: "Korisnik");

            migrationBuilder.RenameColumn(
                name: "slika_korisnika",
                table: "Korisnik",
                newName: "LokacijaSlike");

            migrationBuilder.AddForeignKey(
                name: "FK_Administrator_Drzava_DrzavaID",
                table: "Administrator",
                column: "DrzavaID",
                principalTable: "Drzava",
                principalColumn: "DrzavaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Administrator_KorisnickiNalog_ID",
                table: "Administrator",
                column: "ID",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "KorisnickiNalogId",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_Drzava_DrzavaID",
                table: "Korisnik",
                column: "DrzavaID",
                principalTable: "Drzava",
                principalColumn: "DrzavaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_KorisnickiNalog_ID",
                table: "Korisnik",
                column: "ID",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnikOglas_Korisnik_KorisnikID",
                table: "KorisnikOglas",
                column: "KorisnikID",
                principalTable: "Korisnik",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnikOglas_Oglas_OglasID",
                table: "KorisnikOglas",
                column: "OglasID",
                principalTable: "Oglas",
                principalColumn: "OglasID");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Dostavljac_DostavljacID",
                table: "Narudzba",
                column: "DostavljacID",
                principalTable: "Dostavljac",
                principalColumn: "DostavljacID");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Korisnik_NaruciocID",
                table: "Narudzba",
                column: "NaruciocID",
                principalTable: "Korisnik",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_NarudzbaStavka_Narudzba_NarudzbaID",
                table: "NarudzbaStavka",
                column: "NarudzbaID",
                principalTable: "Narudzba",
                principalColumn: "NarudzbaID");

            migrationBuilder.AddForeignKey(
                name: "FK_NarudzbaStavka_Proizvod_ProizvodID",
                table: "NarudzbaStavka",
                column: "ProizvodID",
                principalTable: "Proizvod",
                principalColumn: "ProizvodID");

            migrationBuilder.AddForeignKey(
                name: "FK_Oglas_Administrator_AutorOglasaID",
                table: "Oglas",
                column: "AutorOglasaID",
                principalTable: "Administrator",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Administrator_AutorPostaID",
                table: "Post",
                column: "AutorPostaID",
                principalTable: "Administrator",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvod_Kategorija_KategorijaID",
                table: "Proizvod",
                column: "KategorijaID",
                principalTable: "Kategorija",
                principalColumn: "KategorijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvod_Proizvodjac_ProizvodjacID",
                table: "Proizvod",
                column: "ProizvodjacID",
                principalTable: "Proizvodjac",
                principalColumn: "ProizvodjacID");

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvodjac_Drzava_DrzavaID",
                table: "Proizvodjac",
                column: "DrzavaID",
                principalTable: "Drzava",
                principalColumn: "DrzavaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Racun_Banka_BankaID",
                table: "Racun",
                column: "BankaID",
                principalTable: "Banka",
                principalColumn: "BankaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Racun_Korisnik_KorisnikID",
                table: "Racun",
                column: "KorisnikID",
                principalTable: "Korisnik",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recenzija_Proizvod_ProizvodID",
                table: "Recenzija",
                column: "ProizvodID",
                principalTable: "Proizvod",
                principalColumn: "ProizvodID");
        }
    }
}
