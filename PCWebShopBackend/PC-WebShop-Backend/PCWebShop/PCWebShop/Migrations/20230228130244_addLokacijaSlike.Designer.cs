﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PCWebShop.Data;

namespace PCWebShop.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230228130244_addLokacijaSlike")]
    partial class addLokacijaSlike
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PCWebShop.Database.Banka", b =>
                {
                    b.Property<int>("BankaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KontaktTel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazivBanke")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BankaID");

                    b.ToTable("Banka");
                });

            modelBuilder.Entity("PCWebShop.Database.BankovniRacun", b =>
                {
                    b.Property<int>("BankovniRacunID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BankaID")
                        .HasColumnType("int");

                    b.Property<string>("BrojRacuna")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumAktiviranjaRacuna")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<double>("StanjeRacuna")
                        .HasColumnType("float");

                    b.HasKey("BankovniRacunID");

                    b.HasIndex("BankaID");

                    b.HasIndex("KorisnikID");

                    b.ToTable("Racun");
                });

            modelBuilder.Entity("PCWebShop.Database.Dostavljac", b =>
                {
                    b.Property<int>("DostavljacID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KontaktTelefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazivDostave")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DostavljacID");

                    b.ToTable("Dostavljac");
                });

            modelBuilder.Entity("PCWebShop.Database.Drzava", b =>
                {
                    b.Property<int>("DrzavaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DrzavaID");

                    b.ToTable("Drzava");
                });

            modelBuilder.Entity("PCWebShop.Database.Kategorija", b =>
                {
                    b.Property<int>("KategorijaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivKategorije")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KategorijaID");

                    b.ToTable("Kategorija");
                });

            modelBuilder.Entity("PCWebShop.Database.KorisnickiNalog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("korisnickoIme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lozinka")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("KorisnickiNalog");
                });

            modelBuilder.Entity("PCWebShop.Database.KorisnikOglas", b =>
                {
                    b.Property<int>("KorisnikOglasID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumPrijave")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<int>("OglasID")
                        .HasColumnType("int");

                    b.HasKey("KorisnikOglasID");

                    b.HasIndex("KorisnikID");

                    b.HasIndex("OglasID");

                    b.ToTable("KorisnikOglas");
                });

            modelBuilder.Entity("PCWebShop.Database.Narudzba", b =>
                {
                    b.Property<int>("NarudzbaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktivna")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DatumKreiranja")
                        .HasColumnType("datetime2");

                    b.Property<int>("DostavljacID")
                        .HasColumnType("int");

                    b.Property<int>("NaruciocID")
                        .HasColumnType("int");

                    b.Property<bool>("Potvrdjena")
                        .HasColumnType("bit");

                    b.HasKey("NarudzbaID");

                    b.HasIndex("DostavljacID");

                    b.HasIndex("NaruciocID");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("PCWebShop.Database.NarudzbaStavka", b =>
                {
                    b.Property<int>("NarudzbaStavkaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cijena")
                        .HasColumnType("float");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("NarudzbaID")
                        .HasColumnType("int");

                    b.Property<int>("ProizvodID")
                        .HasColumnType("int");

                    b.HasKey("NarudzbaStavkaID");

                    b.HasIndex("NarudzbaID");

                    b.HasIndex("ProizvodID");

                    b.ToTable("NarudzbaStavka");
                });

            modelBuilder.Entity("PCWebShop.Database.Oglas", b =>
                {
                    b.Property<int>("OglasID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktivan")
                        .HasColumnType("bit");

                    b.Property<int>("AutorOglasaID")
                        .HasColumnType("int");

                    b.Property<int>("BrojPozicja")
                        .HasColumnType("int");

                    b.Property<string>("CVEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumIsteka")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumObjave")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lokacija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naslov")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sadrzaj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrajanjeOglasa")
                        .HasColumnType("int");

                    b.HasKey("OglasID");

                    b.HasIndex("AutorOglasaID");

                    b.ToTable("Oglas");
                });

            modelBuilder.Entity("PCWebShop.Database.Post", b =>
                {
                    b.Property<int>("PostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutorPostaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumObjave")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naslov")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sadrzaj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("slika_posta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("slika_posta_bytes")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("PostID");

                    b.HasIndex("AutorPostaID");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("PCWebShop.Database.Proizvod", b =>
                {
                    b.Property<int>("ProizvodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cijena")
                        .HasColumnType("float");

                    b.Property<int>("KategorijaID")
                        .HasColumnType("int");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("NaStanju")
                        .HasColumnType("int");

                    b.Property<string>("NazivProizvoda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProizvodjacID")
                        .HasColumnType("int");

                    b.Property<bool>("Snizen")
                        .HasColumnType("bit");

                    b.Property<string>("slika_proizvoda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("slika_proizvoda_bytes")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ProizvodID");

                    b.HasIndex("KategorijaID");

                    b.HasIndex("ProizvodjacID");

                    b.ToTable("Proizvod");
                });

            modelBuilder.Entity("PCWebShop.Database.Proizvodjac", b =>
                {
                    b.Property<int>("ProizvodjacID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrzavaID")
                        .HasColumnType("int");

                    b.Property<string>("NazivProizvodjaca")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProizvodjacID");

                    b.HasIndex("DrzavaID");

                    b.ToTable("Proizvodjac");
                });

            modelBuilder.Entity("PCWebShop.Database.Recenzija", b =>
                {
                    b.Property<int>("RecenzijaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Komentar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ocjena")
                        .HasColumnType("int");

                    b.Property<int>("ProizvodID")
                        .HasColumnType("int");

                    b.HasKey("RecenzijaID");

                    b.HasIndex("ProizvodID");

                    b.ToTable("Recenzija");
                });

            modelBuilder.Entity("PCWebShop.Modul0_Autentifikacija.Models.AutentifikacijaToken", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnickiNalogId")
                        .HasColumnType("int");

                    b.Property<string>("ipAdresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vrijednost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("vrijemeEvidentiranja")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("KorisnickiNalogId");

                    b.ToTable("AutentifikacijaToken");
                });

            modelBuilder.Entity("PCWebShop.Database.Administrator", b =>
                {
                    b.HasBaseType("PCWebShop.Database.KorisnickiNalog");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<int>("DrzavaID")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Spol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TrajanjeUgovora")
                        .HasColumnType("datetime2");

                    b.HasIndex("DrzavaID");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("PCWebShop.Database.Korisnik", b =>
                {
                    b.HasBaseType("PCWebShop.Database.KorisnickiNalog");

                    b.Property<string>("Adresa1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adresa2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ConfirmedEmail")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<int>("DrzavaID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LokacijaSlike")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Spol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserToken")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("DrzavaID");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("PCWebShop.Database.BankovniRacun", b =>
                {
                    b.HasOne("PCWebShop.Database.Banka", "Banka")
                        .WithMany()
                        .HasForeignKey("BankaID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PCWebShop.Database.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Banka");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("PCWebShop.Database.KorisnikOglas", b =>
                {
                    b.HasOne("PCWebShop.Database.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PCWebShop.Database.Oglas", "Oglas")
                        .WithMany()
                        .HasForeignKey("OglasID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("Oglas");
                });

            modelBuilder.Entity("PCWebShop.Database.Narudzba", b =>
                {
                    b.HasOne("PCWebShop.Database.Dostavljac", "Dostavljac")
                        .WithMany()
                        .HasForeignKey("DostavljacID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PCWebShop.Database.Korisnik", "Narucioc")
                        .WithMany()
                        .HasForeignKey("NaruciocID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Dostavljac");

                    b.Navigation("Narucioc");
                });

            modelBuilder.Entity("PCWebShop.Database.NarudzbaStavka", b =>
                {
                    b.HasOne("PCWebShop.Database.Narudzba", "Narudzba")
                        .WithMany("NarudzbaStavke")
                        .HasForeignKey("NarudzbaID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PCWebShop.Database.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Narudzba");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("PCWebShop.Database.Oglas", b =>
                {
                    b.HasOne("PCWebShop.Database.Administrator", "AutorOglasa")
                        .WithMany()
                        .HasForeignKey("AutorOglasaID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AutorOglasa");
                });

            modelBuilder.Entity("PCWebShop.Database.Post", b =>
                {
                    b.HasOne("PCWebShop.Database.Administrator", "AutorPosta")
                        .WithMany()
                        .HasForeignKey("AutorPostaID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AutorPosta");
                });

            modelBuilder.Entity("PCWebShop.Database.Proizvod", b =>
                {
                    b.HasOne("PCWebShop.Database.Kategorija", "Kategorija")
                        .WithMany()
                        .HasForeignKey("KategorijaID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PCWebShop.Database.Proizvodjac", "Proizvodjac")
                        .WithMany()
                        .HasForeignKey("ProizvodjacID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Kategorija");

                    b.Navigation("Proizvodjac");
                });

            modelBuilder.Entity("PCWebShop.Database.Proizvodjac", b =>
                {
                    b.HasOne("PCWebShop.Database.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Drzava");
                });

            modelBuilder.Entity("PCWebShop.Database.Recenzija", b =>
                {
                    b.HasOne("PCWebShop.Database.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("PCWebShop.Modul0_Autentifikacija.Models.AutentifikacijaToken", b =>
                {
                    b.HasOne("PCWebShop.Database.KorisnickiNalog", "korisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("korisnickiNalog");
                });

            modelBuilder.Entity("PCWebShop.Database.Administrator", b =>
                {
                    b.HasOne("PCWebShop.Database.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PCWebShop.Database.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("PCWebShop.Database.Administrator", "ID")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Drzava");
                });

            modelBuilder.Entity("PCWebShop.Database.Korisnik", b =>
                {
                    b.HasOne("PCWebShop.Database.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PCWebShop.Database.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("PCWebShop.Database.Korisnik", "ID")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Drzava");
                });

            modelBuilder.Entity("PCWebShop.Database.Narudzba", b =>
                {
                    b.Navigation("NarudzbaStavke");
                });
#pragma warning restore 612, 618
        }
    }
}
