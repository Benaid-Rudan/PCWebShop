using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PCWebShop.Database
{
    public class Proizvodjac
    {
        [Key]
        public int ProizvodjacID { get; set; }
        public string NazivProizvodjaca { get; set; }

        [ForeignKey(nameof(DrzavaID))]
        public int DrzavaID { get; set; }
        public Drzava Drzava { get; set; }
    }
}
