using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCWebShop.Data;
using PCWebShop.Database;
using PCWebShop.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PCWebShop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProizvodjacController : ControllerBase
    {
        private readonly Context _context;
        public ProizvodjacController(Context context)
        {
            _context= context; 
        }

        [HttpPost]
        public ActionResult Add([FromBody] ProizvodjacAddVM x)
        {
            var newProizvodjac = new Proizvodjac
            {
                NazivProizvodjaca = x.NazivProizvodjaca,
                DrzavaID=x.DrzavaID,
            };
            _context.Add(newProizvodjac);
            _context.SaveChanges();
            return Ok(newProizvodjac.ProizvodjacID);
        }
        [HttpPost]
        public ActionResult Delete([FromBody] Proizvodjac x)
        {
            Proizvodjac proizvodjac = _context.Proizvodjac.Find(x.ProizvodjacID);

            if (proizvodjac == null)
                return BadRequest("pogresan ID");

            _context.Remove(proizvodjac);

            _context.SaveChanges();
            return Ok(proizvodjac);
        }

        [HttpGet]
        public List<ProizvodjacGetAllVM> GetAll()
        {

            var data = _context.Proizvodjac.OrderBy(p => p.ProizvodjacID)
                .Select(p => new ProizvodjacGetAllVM()
                {
                    ProizvodjacID = p.ProizvodjacID,
                    NazivProizvodjaca = p.NazivProizvodjaca,
                    Drzava = p.Drzava,
                    DrzavaID = p.DrzavaID
                }).AsQueryable();
            return data.Take(100).ToList();
        }

    }

   

   
}
