using IdentityServer4.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace PCWebShop.ViewModels
{
    public class KorisnikAddVM
    {
        [Required(ErrorMessage = "Obavezan unos polja!")]
        public string korisnickoIme { get; set; }
        [Required(ErrorMessage = "Obavezan unos polja!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Obavezan unos polja!")]
        public int DrzavaID { get; set; }
        [Required(ErrorMessage = "Obavezan unos polja!")]
        public string Lozinka { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Spol { get; set; }

    }
}
