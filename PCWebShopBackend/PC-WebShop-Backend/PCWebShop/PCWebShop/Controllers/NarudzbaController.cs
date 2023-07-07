using Microsoft.AspNetCore.Mvc;
using PCWebShop.Core.Infrastructure.Enums;
using PCWebShop.Core.Interfaces;
using PCWebShop.Data;
using PCWebShop.Database;
using PCWebShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PCWebShop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NarudzbaController : ControllerBase
    {
        private readonly Context _context;
        private readonly INarudzbaService _narudzbaService;

        public NarudzbaController(Context context, INarudzbaService narudzbaService)
        {
            _context = context;
            _narudzbaService = narudzbaService;
        }

        [HttpGet]
        public List<NarudzbaGetAllVM> GetAll()
        {

            var data = _context.Narudzba.OrderBy(s => s.NarudzbaID)
                .Select(s => new NarudzbaGetAllVM()
                {
                    NarudzbaID = s.NarudzbaID,
                    Aktivna = s.Aktivna,
                    DatumKreiranja = s.DatumKreiranja,
                    DostavljacID = s.DostavljacID,
                    dostavljac = s.Dostavljac,
                    narucioc = s.Narucioc,
                    NaruciocID = s.NaruciocID,
                    Potvrdjena = s.Potvrdjena
                }).AsQueryable();

            return data.Take(100).ToList();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] KorpaVM request, CancellationToken cancellationToken)
        {
            var result = await _narudzbaService.AddNarudzba(request, cancellationToken);

            if (!result.IsValid)
                return BadRequest(result);

            return Ok(result);
        }


        [HttpPost]
        public ActionResult AddNarudzba([FromBody] KorpaVM request, CancellationToken cancellationToken)
        {

            var user = _context.Korisnik.Where(x => x.ID == request.KorisnikID).FirstOrDefault();
            var order = new Narudzba()
            {
                Aktivna = true,
                DatumKreiranja = DateTime.Now,
                NaruciocID = request.KorisnikID,
                Potvrdjena = false,
                DostavljacID = 2
            };
            var orderResult = _context.Narudzba.Add(order);
            _context.SaveChanges();

            for (int i = 0; i < request.ID.Length; i++)
            {
                for (int j = 0; j < request.Kolicina[i]; j++)
                {
                    var stavka = new NarudzbaStavka()
                    {
                        NarudzbaID = orderResult.Entity.NarudzbaID,
                        ProizvodID = request.ID[i]
                    };
                    _context.NarudzbaStavka.Add(stavka);
                }
                _context.SaveChanges();
            }

            return Get(order.NarudzbaID);

        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_context.Narudzba.Where(s => s.NarudzbaID == id).FirstOrDefault());
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] NarudzbaUpdateVM x)
        {
            Narudzba narudzba = _context.Narudzba.Where(s => s.NarudzbaID == id).FirstOrDefault();

            if (narudzba == null)
                return BadRequest("Pogresan ID");

            narudzba.NaruciocID = x.NaruciocID;
            narudzba.Potvrdjena = x.Potvrdjena;
            narudzba.Aktivna = x.Aktivna;
            narudzba.DatumKreiranja = x.DatumKreiranja;
            narudzba.DostavljacID = x.DostavljacID;

            _context.SaveChanges();
            return Get(id);
        }

        [HttpPost("{id}")]
        public async void Delete(int id)
        {
            Narudzba narudzba = _context.Narudzba.Find(id);

            if (narudzba == null)
                throw new Exception("Pogrean ID");

            _context.Remove(narudzba);

            _context.SaveChanges();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44304/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage msg = await client.GetAsync("api/chart");
            }
        }
    }

    
}
