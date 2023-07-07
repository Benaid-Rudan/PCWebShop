using PCWebShop.Modul0_Autentifikacija.Models;
using Microsoft.EntityFrameworkCore;
using PCWebShop.Database;
using System.Collections.Generic;

namespace PCWebShop.Data
{
    public partial class Context : DbContext 
    {
        public Context() { }
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Kategorija> Kategorija { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Banka> Banka { get; set; }
        public DbSet<BankovniRacun> Racun { get; set; }
        public DbSet<Proizvodjac> Proizvodjac { get; set; }
        public DbSet<Dostavljac> Dostavljac { get; set; }
        public DbSet<Proizvod> Proizvod { get; set; }
        public DbSet<Oglas> Oglas { get; set; }
        public DbSet<KorisnikOglas> KorisnikOglas { get; set; }
        public DbSet<Recenzija> Recenzija { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Narudzba> Narudzba { get; set; }
        public DbSet<NarudzbaStavka> NarudzbaStavka { get; set; }
        public DbSet<AutentifikacijaToken> AutentifikacijaToken { get; set; }
        public List<Korisnik> korisnici { get; set; }


        public Context(
            DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
