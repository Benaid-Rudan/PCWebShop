using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCWebShop.Data;
using PCWebShop.Database;
using PCWebShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCWebShop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class KategorijaController : ControllerBase
    {
        private readonly Context _context;

        public KategorijaController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Add([FromBody] KategorijaAddVM x)
        {

            var novaKategorija = new Kategorija
            {

               NazivKategorije=x.NazivKategorije
            };
            _context.Add(novaKategorija);
            _context.SaveChanges();

            return Ok(novaKategorija.KategorijaID);

        }


        [HttpGet]
        public List<KategorijaGetAllVM> GetAll()
        {

            var kategorija = _context.Kategorija.OrderBy(p => p.KategorijaID)
                .Select(p => new KategorijaGetAllVM()
                {
                    KategorijaID=p.KategorijaID,
                    NazivKategorije=p.NazivKategorije
                }).AsQueryable();
            return kategorija.Take(100).ToList();
        }


        [HttpPost]
        public ActionResult Delete([FromBody] Kategorija x)
        {
            Kategorija kategorija = _context.Kategorija.Find(x.KategorijaID);

            if (kategorija == null)
                return BadRequest("Pogresan ID");

            _context.Remove(kategorija);

            _context.SaveChanges();
            return Ok(kategorija);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_context.Kategorija.FirstOrDefault(k => k.KategorijaID == id));
        }

    }

}
