using FIT_Api_Examples.Helper;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PCWebShop.Core.Interfaces;
using PCWebShop.Data;
using PCWebShop.Database;
using PCWebShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace PCWebShop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class KorisnikController : ControllerBase
    {
        private readonly Context _context;
        private readonly IConfiguration _config;
        private readonly IEmailSender _emailSender;

        public KorisnikController(Context context,IConfiguration config, IEmailSender emailSender)
        {
           _context = context;
           _config = config;
           _emailSender = emailSender;
          
        }

        [HttpGet]
        public List<KorisnikGetAllVM> GetAll(string ime_prezime)
        {
           // if (!HttpContext.GetLoginInfo().isLogiran)
           //     return BadRequest("Nije logiran");

            var data = _context.Korisnik.OrderBy(s => s.ID)
                .Where(x => ime_prezime == null || (x.Ime + " " + x.Prezime).StartsWith(ime_prezime) || (x.Ime + " " + x.Prezime).StartsWith(ime_prezime))
               .Select(s => new KorisnikGetAllVM()
               {
                   ID = s.ID,
                   Ime = s.Ime,
                   DatumRodjenja = s.DatumRodjenja,
                   KorisnickoIme = s.korisnickoIme,
                   drzava = s.Drzava,
                   DrzavaID = s.DrzavaID,
                   Prezime = s.Prezime,
                   Email = s.Email,
                   Spol = s.Spol,
                   Lozinka = s.lozinka,
                   Adresa1 = s.Adresa1,
                   Adresa2 = s.Adresa2

               }).AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_context.Korisnik.FirstOrDefault(k => k.ID == id));
        }

        [HttpPost]
        public async void Add([FromBody] KorisnikAddVM k)
        {
            if (k == null || !ModelState.IsValid)
                throw new Exception("Greska!");

            try
            {

                var noviKorisnik = new Korisnik();

                noviKorisnik.Ime = k.Ime;
                noviKorisnik.Prezime = k.Prezime;
                noviKorisnik.DrzavaID = k.DrzavaID;
                noviKorisnik.DatumRodjenja = k.DatumRodjenja;
                noviKorisnik.Spol = k.Spol;
                noviKorisnik.korisnickoIme = k.korisnickoIme;
                noviKorisnik.lozinka = k.Lozinka;
                noviKorisnik.Email = k.Email;


                string token = TokenGenerator.Generate(100);

                noviKorisnik.UserToken = token;


                _context.Add(noviKorisnik);
                _context.SaveChanges();


                var uriBuilder = new UriBuilder(_config["ReturnPaths:ConfirmEmail"]);
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["token"] = token.ToString();
                query["userid"] = noviKorisnik.ID.ToString();
                uriBuilder.Query = query.ToString();

                var urlString = "<html><body><p>Molimo vas da potvrdite vašu email adresu.</p><a href='" + uriBuilder.ToString() + "'>" + token + "  </ a > <br> <p>Vaš PCShop.</p></ body ></ html > ";


                var senderEmail = _config["ReturnPaths:SenderEmail"];

                await _emailSender.SendEmailAsync(senderEmail, noviKorisnik.Email, "Confirm your email address", urlString);


                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44304/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage msg = await client.GetAsync("api/chart");
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public ActionResult ConfirmEmail(ConfirmEmailVM model)
        {
            int id = int.Parse(model.UserId);
            var user = _context.Korisnik.FirstOrDefault(x => x.ID == id && x.UserToken == model.Token);


            if (user == null)
            {
                return BadRequest();
            }

            user.ConfirmedEmail = true;

            _context.SaveChanges();
            return Ok();
        }


        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] KorisnikUpdateVM x)
        {
            Korisnik korisnik = _context.Korisnik.Where(k => k.ID == id).FirstOrDefault(s => s.ID == id);

            if (korisnik == null)
                return BadRequest("pogresan ID");
            korisnik.Ime = x.Ime;
            korisnik.Prezime = x.Prezime;
            korisnik.korisnickoIme = x.korisnickoIme;
            korisnik.DatumRodjenja = x.DatumRodjenja;
            korisnik.DrzavaID = x.DrzavaID;
            korisnik.Spol = x.Spol;
            korisnik.Email = x.Email;
            korisnik.Adresa1 = x.Adresa1;
            korisnik.Adresa2 = x.Adresa2;


            _context.SaveChanges();
            return Get(id);
        }

        [HttpPost("{id}")]
        public async void Delete(int id)
        {
            Korisnik korisnik = _context.Korisnik.Find(id);

            if (korisnik == null)
                throw new Exception("Pogresan ID");

            _context.Remove(korisnik);

            _context.SaveChanges();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44304/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage msg = await client.GetAsync("api/Chart");
            }
        }
    }

}
