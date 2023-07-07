using PCWebShop.Database;

namespace PCWebShop.ViewModels
{
    public class ProizvodGetAllVM
    {
        public int ProizvodID { get; set; }
        public string NazivProizvoda { get; set; }
        public string Opis { get; set; }
        public double Cijena { get; set; }
        public int NaStanju { get; set; }
        public int Kolicina { get; set; }
        public bool Snizen { get; set; } = false;
        public int KategorijaID { get; set; }
        public Kategorija Kategorija { get; set; }
        public int ProizvodjacID { get; set; }
        public Proizvodjac Proizvodjac { get; set; }
        public string slika_proizvoda_nova_base64 { get; set; }

    }
}
