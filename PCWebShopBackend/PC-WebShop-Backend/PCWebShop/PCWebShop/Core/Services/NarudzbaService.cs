using Mailjet.Client.Resources;
using PCWebShop.Core.Infrastructure.Enums;
using PCWebShop.Core.Interfaces;
using PCWebShop.Data;
using PCWebShop.Database;
using PCWebShop.ViewModels;
using System.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;
using PCWebShop.Core.Infrastructure;
using System.Net.Http;

namespace PCWebShop.Core.Services
{
    public class NarudzbaService :INarudzbaService
    {
        private readonly Context _context;

        public NarudzbaService(Context context)
        {
            _context = context;
        }

         public async Task<MessageResponse> AddNarudzba(KorpaVM request, CancellationToken cancellationToken)
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
            var orderResult = await _context.Narudzba.AddAsync(order);
            await _context.SaveChangesAsync();

            for (int i = 0; i < request.ID.Length; i++)
            {
                for (int j = 0; j < request.Kolicina[i]; j++)
                {
                    var stavka = new NarudzbaStavka()
                    {
                        NarudzbaID = orderResult.Entity.NarudzbaID,
                        ProizvodID = request.ID[i],
                        
                    };
                    await _context.NarudzbaStavka.AddAsync(stavka);
                }
                await _context.SaveChangesAsync();
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44304/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage msg = await client.GetAsync("api/chart");
            }

            return new MessageResponse
            {
                IsValid = true,
                Status = ExceptionCodeEnum.Success,
                Info = "Uspjesno!"
            };
        }
    }
}
