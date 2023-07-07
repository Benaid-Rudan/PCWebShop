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
    public class ProizvodController : ControllerBase
    {
        private readonly Context _context;

        public ProizvodController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async void  Add([FromBody] ProizvodAddVM x)
        {
            var noviProizvod = new Proizvod();

            noviProizvod.NazivProizvoda = x.NazivProizvoda;
            noviProizvod.Opis = x.Opis;
            noviProizvod.Cijena = x.Cijena;
            noviProizvod.NaStanju = x.NaStanju;
            noviProizvod.Kolicina =x.Kolicina;
            noviProizvod.KategorijaID = x.KategorijaID;
            noviProizvod.ProizvodjacID = x.ProizvodjacID;
            noviProizvod.Snizen = x.Snizen;

            _context.Add(noviProizvod);
            _context.SaveChanges();

            if (!string.IsNullOrEmpty(x.slika_proizvoda_nova_base64))
            {
                byte[] nova_slika = x.slika_proizvoda_nova_base64.parseBase64();

                noviProizvod.slika_proizvoda_bytes = nova_slika;
                _context.SaveChanges();
            }


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44304/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage msg = await client.GetAsync("api/chart2");
            }

        }

        [HttpGet]
        public List<ProizvodGetAllVM> GetAll()
        {
            var podaci = _context.Proizvod.OrderBy(p => p.ProizvodID)
                .Select(p => new ProizvodGetAllVM()
                {
                    ProizvodID=p.ProizvodID,
                    NazivProizvoda=p.NazivProizvoda,
                    Opis=p.Opis,
                    Cijena=p.Cijena,
                    NaStanju=p.NaStanju,
                    Kolicina=1,
                    Snizen=p.Snizen,
                    KategorijaID=p.KategorijaID,
                    Kategorija=p.Kategorija,
                    ProizvodjacID=p.ProizvodjacID,
                    Proizvodjac=p.Proizvodjac,
                }).AsQueryable();

            return podaci.Take(100).ToList();

        }

        [HttpPost]
        public async void  Delete([FromBody] Proizvod p)
        {
            Proizvod proizvod = _context.Proizvod.Find(p.ProizvodID);

            if (proizvod == null)
                throw new Exception("Pogresan ID");

            _context.Remove(proizvod);
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
        public ActionResult Update(int id,[FromBody] ProizvodUpdateVM p)
        {
            Proizvod proizvod = _context.Proizvod.Where(x => x.ProizvodID == id).FirstOrDefault(y => y.ProizvodID == id);

            if (proizvod == null)
                return BadRequest("Pogresan ID");

            proizvod.NazivProizvoda = p.NazivProizvoda;
            proizvod.Opis = p.Opis;
            proizvod.NaStanju = p.NaStanju;
            proizvod.Kolicina = 1;
            proizvod.Cijena = p.Cijena;
            proizvod.ProizvodjacID = p.ProizvodjacID;
            proizvod.KategorijaID = p.KategorijaID;
            proizvod.Snizen = p.Snizen;

            if (!string.IsNullOrEmpty(p.slika_proizvoda_nova_base64))
            {
                byte[] nova_slika = p.slika_proizvoda_nova_base64.parseBase64();

                proizvod.slika_proizvoda_bytes = nova_slika;
                _context.SaveChanges();
               
            }

            _context.SaveChanges();

            return Ok();
        }

       [HttpGet("{proizvodID}")]
       public ActionResult GetSlikaProizvoda(int proizvodID)
       {
            Proizvod proizvod = _context.Proizvod.Find(proizvodID);

            byte[] slika = proizvod.slika_proizvoda_bytes;

            if (slika==null || slika.Length==0)
            {
                slika = Fajlovi.Ucitaj(Config.SlikeFolder + "empty.png");
            }

            return File(slika, "image/png");
           
       }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_context.Proizvod.Include(p => p.Kategorija).Include(p => p.Proizvodjac).FirstOrDefault(p => p.ProizvodID == id));
        }

        [HttpGet]
        public ActionResult<PagedList<Proizvod>> GetAllPaged(int items_per_page, int page_number)
        {
            var data = _context.Proizvod.Include(s=>s.Proizvodjac).AsQueryable();
            return PagedList<Proizvod>.Create(data, page_number, items_per_page);
        }
    }

}
