using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCWebShop.Data;
using PCWebShop.Database;
using PCWebShop.Helper;
using PCWebShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;

namespace PCWebShop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PostController : ControllerBase
    {
        private readonly Context _context;

        public PostController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public List<PostGetAllVM> GetAll()
        {
            var data = _context.Post.OrderBy(p => p.PostID)
                .Select(p => new PostGetAllVM()
                {
                    ID = p.PostID,
                    AutorPosta = p.AutorPosta,
                    AutorPostaID = p.AutorPostaID,
                    DatumObjave = p.DatumObjave,
                    Naslov = p.Naslov,
                    Sadrzaj = p.Sadrzaj
                }).AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpPost]
        public async void Add([FromBody] PostAddVM p)
        {
            var noviPost = new Post();

            noviPost.Naslov = p.naslov;
            noviPost.Sadrzaj = p.sadrzaj;
            noviPost.AutorPostaID = p.autorPostaID;
            noviPost.DatumObjave = p.DatumObjave;
            
            _context.Add(noviPost);
            _context.SaveChanges();

            if (!string.IsNullOrEmpty(p.slika_posta_nova_base64))
            {
                byte[] nova_slika = p.slika_posta_nova_base64.parseBase64();

                noviPost.slika_posta_bytes = nova_slika;
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

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] PostUpdateVM p)
        {
            Post post = _context.Post.Where(p => p.PostID == id).FirstOrDefault();

            if (post == null)
                return BadRequest("Pogresan ID");

            post.AutorPostaID = p.AutorPostaID;
            post.Naslov = p.Naslov;
            post.Sadrzaj = p.Sadrzaj;
            post.DatumObjave = p.DatumObjave;

            if (!string.IsNullOrEmpty(p.slika_posta_nova_base64))
            {
                byte[] nova_slika = p.slika_posta_nova_base64.parseBase64();

                post.slika_posta_bytes = nova_slika;
                _context.SaveChanges();

            }
            _context.SaveChanges();
            return Ok(post);

        }


        [HttpPost]
        public async void Delete([FromBody] Post p)
        {
            Post post = _context.Post.Find(p.PostID);

            if (post == null)
                throw new Exception("Pogresan ID");

            _context.Remove(post);
            _context.SaveChanges();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44304/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage msg = await client.GetAsync("api/chart2");
            }
        }

        [HttpGet("{postID}")]
        public ActionResult GetSlikaPosta(int postID)
        {
            Post post = _context.Post.Find(postID);

            if (post == null)
                return BadRequest("Pogrsan ID");
       
            byte[] slika = post.slika_posta_bytes;

            if (slika == null || slika.Length == 0)
            {
                slika = Fajlovi.Ucitaj(Config.SlikeFolder + "empty.png");
            }

            return File(slika, "image/png");

        }

        [HttpGet]
        public ActionResult<PagedList<Post>> GetAllPaged(int items_per_page, int page_number)
        {
            var data = _context.Post.Include(x => x.AutorPosta).AsQueryable();
            return PagedList<Post>.Create(data, page_number, items_per_page);
        }
    }

    
}
