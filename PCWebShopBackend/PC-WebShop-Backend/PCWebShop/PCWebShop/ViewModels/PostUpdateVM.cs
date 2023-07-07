using System;

namespace PCWebShop.ViewModels
{
    public class PostUpdateVM
    {
        public string Naslov { get; set; }
        public string Sadrzaj { get; set; }
        public int AutorPostaID { get; set; }
        public DateTime DatumObjave { get; set; }
        public string slika_posta_nova_base64 { get; set; }
    }
}
