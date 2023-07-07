using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PCWebShop.Database
{
    public class Proizvod
    {
        [Key]
        public int ProizvodID { get; set; }
        public string NazivProizvoda { get; set; }
        public double Cijena { get; set; }
        public int Kolicina { get; set; }
        public int NaStanju { get; set; }
        public string Opis { get; set; }
        public bool Snizen { get; set; } = false;
        public string slika_proizvoda { get; set; }
        public byte[] slika_proizvoda_bytes { get; set; }

        [ForeignKey(nameof(KategorijaID))]
        public int KategorijaID { get; set; }
        public Kategorija Kategorija { get; set; }

        [ForeignKey(nameof(ProizvodjacID))]
        public int ProizvodjacID { get; set; }
        public Proizvodjac Proizvodjac { get; set; }
        
    }
}
