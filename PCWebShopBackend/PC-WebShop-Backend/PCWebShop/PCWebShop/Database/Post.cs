using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PCWebShop.Database
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        public string Naslov { get; set; }
        public string Sadrzaj { get; set; }

        [ForeignKey(nameof(AutorPostaID))]
        public int AutorPostaID { get; set; }
        public Administrator AutorPosta { get; set; }

        public DateTime DatumObjave { get; set; }
        public string slika_posta { get; set; }
        public byte[] slika_posta_bytes { get; set; }
    }
}
