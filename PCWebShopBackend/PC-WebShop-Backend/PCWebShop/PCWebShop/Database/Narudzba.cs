using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PCWebShop.Database
{
    public class Narudzba
    {
        [Key]
        public int NarudzbaID { get; set; }
        public DateTime DatumKreiranja { get; set; }

        [ForeignKey(nameof(NaruciocID))]
        public int NaruciocID { get; set; }
        public Korisnik Narucioc { get; set; }

        [ForeignKey(nameof(DostavljacID))]
        public int DostavljacID { get; set; }
        public Dostavljac Dostavljac { get; set; }

        public ICollection<NarudzbaStavka> NarudzbaStavke { get; set; }

        public bool Aktivna { get; set; }
        public bool Potvrdjena { get; set; }
    }
}
