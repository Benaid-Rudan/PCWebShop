using PCWebShop.Database;

namespace PCWebShop.ViewModels
{
    public class ProizvodjacGetAllVM
    {
        public int ProizvodjacID { get;  set; }
        public string NazivProizvodjaca { get;  set; }
        public Drzava Drzava { get;  set; }
        public int DrzavaID { get;  set; }
    }
}