using PCWebShop.Database;
using System;

namespace PCWebShop.ViewModels
{
    public class NarudzbaGetAllVM
    {
        public int NarudzbaID { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public int DostavljacID { get; set; }
        public Korisnik narucioc { get; set; }
        public Dostavljac dostavljac { get; set; }
        public bool Aktivna { get; set; }
        public bool Potvrdjena { get; set; }
        public int NaruciocID { get; set; }
    }
}
