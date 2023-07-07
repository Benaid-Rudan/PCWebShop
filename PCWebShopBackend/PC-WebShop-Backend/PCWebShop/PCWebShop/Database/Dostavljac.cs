using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PCWebShop.Database
{
    public class Dostavljac
    {
        [Key]
        public int DostavljacID { get; set; }
        public string NazivDostave { get; set; }
        public string Adresa { get; set; }
        public string KontaktTelefon { get; set; }
      
    }
}
