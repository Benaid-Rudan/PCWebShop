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
    public class AdministratorController:ControllerBase
    {
        private readonly Context _context;

        public AdministratorController(Context context)
        {
            this._context = context;
        }

        [HttpPost]
        public ActionResult Add([FromBody] AdministratorAddVM a)
        {
            var newAdministrator = new Administrator
            {
                Ime = a.Ime,
                Prezime = a.Prezime,
                korisnickoIme = a.korisnickoIme,
                DatumRodjenja = a.DatumRodjenja,
                Spol = a.Spol,
                DrzavaID = a.DrzavaID,
                lozinka = a.Lozinka,
                TrajanjeUgovora = a.trajanjeUgovora
            };
            _context.Add(newAdministrator);
            _context.SaveChanges();
            return Ok(newAdministrator.ID);

        }
        
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_context.Administrator.FirstOrDefault(k => k.ID == id));
        }

        [HttpGet]
        public List<AdministratorGetAllVM> GetAll(string ime_prezime)
        {

            var data = _context.Administrator.OrderBy(s => s.ID)
                .Where(x => ime_prezime == null || (x.Ime + " " + x.Prezime).StartsWith(ime_prezime) || (x.Ime + " " + x.Prezime).StartsWith(ime_prezime))
               .Select(s => new AdministratorGetAllVM()
               {
                   ID = s.ID,
                   Ime = s.Ime,
                   DatumRodjenja = s.DatumRodjenja,
                   KorisnickoIme = s.korisnickoIme,
                   DrzavaID = s.DrzavaID,
                   Prezime = s.Prezime,
                   Spol = s.Spol,
                   trajanjeUgovora = s.TrajanjeUgovora
               }).AsQueryable();

            return data.Take(100).ToList();
        }
        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] AdministratorUpdateVM x)
        {
            Administrator administrator = _context.Administrator.Where(k => k.ID == id).FirstOrDefault(s => s.ID == id);

            if (administrator == null)
                return BadRequest("pogresan ID");

            administrator.Ime = x.Ime;
            administrator.Prezime = x.Prezime;
            administrator.korisnickoIme = x.korisnickoIme;
            administrator.lozinka = x.Lozinka;
            administrator.DatumRodjenja = x.DatumRodjenja;
            administrator.DrzavaID = x.DrzavaID;
            administrator.Spol = x.Spol;

            _context.SaveChanges();
            return Get(id);
        }
        [HttpPost]
        public ActionResult Delete([FromBody] Administrator a)
        {
            Administrator administrator = _context.Administrator.Find(a.ID);

            if (administrator == null)
                return BadRequest("pogresan ID");

            _context.Remove(administrator);

            _context.SaveChanges();
            return Ok(administrator);
        }
    }

}
