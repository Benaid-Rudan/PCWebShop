using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;


namespace PCWebShop.Database

{
    [Table("KorisnickiNalog")]
    public class KorisnickiNalog 
    {
        [Key]
        public int ID { get; set; }
        public string korisnickoIme { get; set; }
        [JsonIgnore]
        public string lozinka { get; set; }

       [JsonIgnore]
       public Korisnik korisnik => this as Korisnik;
      
       [JsonIgnore]
       public Administrator administrator => this as Administrator;
        public bool isKupac => korisnik != null;
        public bool isAdmin => administrator != null;



    }
}
