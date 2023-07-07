using System;

namespace PCWebShop.ViewModels
{
    public class PostAddVM
    {
        public int autorPostaID { get;  set; }
        public string naslov { get;  set; }
        public string sadrzaj { get;  set; }
        public DateTime DatumObjave { get;  set; }
        public string slika_posta_nova_base64 { get; set; }
    }
}
