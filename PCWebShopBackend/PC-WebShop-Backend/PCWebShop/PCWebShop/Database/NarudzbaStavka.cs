using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PCWebShop.Database
{
    public class NarudzbaStavka
    {
        [Key]
        public int NarudzbaStavkaID { get; set; }
        public int Kolicina { get; set; }
        public double Cijena { get; set; }

        [ForeignKey(nameof(ProizvodID))]
        public int ProizvodID { get; set; }
        public Proizvod Proizvod { get; set; }

        [ForeignKey(nameof(NarudzbaID))]
        public int NarudzbaID { get; set; }
        public Narudzba Narudzba { get; set; }
    }
}
