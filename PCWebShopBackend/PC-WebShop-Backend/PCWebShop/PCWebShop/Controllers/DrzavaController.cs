using Microsoft.AspNetCore.Mvc;
using PCWebShop.Data;
using PCWebShop.Database;
using PCWebShop.Helper;
using PCWebShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCWebShop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DrzavaController:ControllerBase
    {
        private readonly Context _context;

        public DrzavaController(Context context)
        {
            this._context = context;
        }

        [HttpPost]
        public Drzava Add([FromBody] DrzavaAddVM x)
        {
            var novaDrzava = new Drzava
            {
                Naziv = x.Naziv,
            };

            _context.Add(novaDrzava);
            _context.SaveChanges();
            return novaDrzava;
        }

        [HttpGet]
        public List<DrzavaGetAllVM> GetAll()
        {
            var drzava = _context.Drzava
               .OrderBy(s => s.Naziv)
               .Select(s => new DrzavaGetAllVM()
               {
                   ID = s.DrzavaID,
                   Naziv = s.Naziv,
               })
               .AsQueryable();
            return drzava.Take(100).ToList();
        }
        [HttpPost("{id}")]
       public ActionResult Update(int id ,[FromBody] DrzavaUpdateVM x) 
        {
            Drzava drzava = _context.Drzava.Where(d => d.DrzavaID == id).FirstOrDefault();

            if (drzava == null)
                return BadRequest("Pogresan ID");

            drzava.Naziv = x.Naziv;

            _context.SaveChanges();
            return Ok(drzava);
        
        }
        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Drzava drzava = _context.Drzava.Find(id);

            if (drzava == null )
                return BadRequest("Pogresan ID");

            _context.Remove(drzava);

            _context.SaveChanges();
            return Ok(drzava);
        }
        [HttpGet]
        public List<CmbStavke> GetAll_ForCmb()
        {
            return _context.Drzava
                .OrderByDescending(x => x.DrzavaID)
                .Select(s => new CmbStavke
                {
                    opis = s.Naziv,
                    id = s.DrzavaID
                })
                .ToList();
        }
    }
   
}
