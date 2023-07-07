using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCWebShop.Data;
using PCWebShop.Database;
using PCWebShop.Helper;
using PCWebShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace PCWebShop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OglasController : ControllerBase
    {
        private readonly Context _context;
        public OglasController(Context context)
        {
            _context = context; 
        }


        [HttpGet]
        public List<OglasGetAllVM> GetAll()
        {
            var data = _context.Oglas.OrderBy(o => o.OglasID)
                .Select(o => new OglasGetAllVM()
                {
                    OglasID = o.OglasID,
                    naslov = o.Naslov,
                    sadrzaj = o.Sadrzaj,
                    brojPozicija = o.BrojPozicja,
                    datumObjave = o.DatumObjave,
                    datumIsteka = o.DatumIsteka,
                    lokacija = o.Lokacija,
                    trajanjeOglasa = o.TrajanjeOglasa,
                    administrator = o.AutorOglasa,
                    administratorID = o.AutorOglasaID,
                    aktivan=o.Aktivan,
                    cvEmail=o.CVEmail
                }).AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpPost]
        public async void Add([FromBody] OglasAddVM o)
        {
            var newOglas = new Oglas
            {
                Naslov = o.naslov,
                Sadrzaj = o.sadrzaj,
                BrojPozicja = o.brojPozicija,
                DatumObjave = o.datumObjave,
                DatumIsteka = o.datumIsteka,
                Lokacija = o.lokacija,
                TrajanjeOglasa = o.trajanjeOglasa,
                AutorOglasaID = o.administratorID,
                Aktivan=o.aktivan,
                CVEmail=o.cvEmail
            };
            _context.Add(newOglas);
            _context.SaveChanges();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44304/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage msg = await client.GetAsync("api/chart2");
            }
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] OglasUpdateVM o)
        {
            Oglas oglas = _context.Oglas.Where(o => o.OglasID == id).FirstOrDefault(o=>o.OglasID==id);

            if (oglas == null)
                return BadRequest("pogresan ID");
            oglas.Naslov = o.naslov;
            oglas.Sadrzaj = o.sadrzaj;
            oglas.BrojPozicja = o.brojPozicija;
            oglas.DatumObjave = o.datumObjave;
            oglas.DatumIsteka = o.datumIsteka;
            oglas.Lokacija = o.lokacija;
            oglas.TrajanjeOglasa = o.trajanjeOglasa;
            oglas.AutorOglasaID = o.administratorID;
            oglas.Aktivan = o.aktivan;
            oglas.CVEmail = o.cvEmail;
            _context.SaveChanges();
            return Ok(oglas);
        }

        [HttpPost]
        public async void Delete([FromBody] Oglas o)
        {
            Oglas oglas = _context.Oglas.Find(o.OglasID);
            if (oglas == null)
                throw new Exception("Pogresan ID");
            _context.Remove(oglas);
            _context.SaveChanges();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44304/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage msg = await client.GetAsync("api/chart2");
            }
        }

    }

    
}
