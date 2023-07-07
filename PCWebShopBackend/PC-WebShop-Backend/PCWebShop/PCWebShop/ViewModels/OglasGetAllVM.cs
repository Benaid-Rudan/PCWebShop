using PCWebShop.Database;
using System;

namespace PCWebShop.ViewModels
{
    public class OglasGetAllVM
    {
        public int OglasID { get; set; }
        public string naslov { get; set; }
        public string sadrzaj { get; set; }
        public int brojPozicija { get; set; }
        public DateTime datumObjave { get; set; } = DateTime.Now;
        public DateTime datumIsteka { get; set; }
        public string lokacija { get; set; }
        public int trajanjeOglasa { get; set; }
        public Administrator administrator { get; set; }
        public int administratorID { get; set; }
        public bool aktivan { get; set; }
        public string cvEmail { get;  set; }
    }
}
