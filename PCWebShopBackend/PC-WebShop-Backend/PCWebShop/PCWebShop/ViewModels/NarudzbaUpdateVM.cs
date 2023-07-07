using System;

namespace PCWebShop.ViewModels
{
    public class NarudzbaUpdateVM
    {
        public DateTime DatumKreiranja { get; set; }
        public int NaruciocID { get; set; }
        public int DostavljacID { get; set; }
        public bool Aktivna { get; set; }
        public bool Potvrdjena { get; set; }
    }
}
