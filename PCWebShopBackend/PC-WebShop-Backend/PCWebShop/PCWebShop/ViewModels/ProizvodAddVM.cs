namespace PCWebShop.ViewModels
{
    public class ProizvodAddVM
    {
        public string NazivProizvoda { get; set; }
        public string Opis { get; set; }
        public double Cijena { get; set; }
        public int NaStanju { get; set; }
        public int Kolicina { get; set; }
        public int KategorijaID { get; set; }
        public int ProizvodjacID { get; set; }
        public bool Snizen { get; set; } = false;
        public string slika_proizvoda_nova_base64 { get; set; }
    }
}
