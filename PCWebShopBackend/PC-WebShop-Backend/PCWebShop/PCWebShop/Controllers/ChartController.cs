using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PCWebShop.Database;
using PCWebShop.DataStorage;
using PCWebShop.HubConfig;
using PCWebShop.Models;
using PCWebShop.TimerFeatures;
using System.Collections.Generic;

namespace PCWebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly IHubContext<ChartHub> _hub;
        private readonly TimerManager _timer;
        private readonly KorisnikController _korisnik;
        private readonly NarudzbaController _narudzbe;

        public ChartController(IHubContext<ChartHub> hub, TimerManager timer, KorisnikController korisnikController, NarudzbaController narudzbe)
        {
            _hub = hub;
            _timer = timer;
            _korisnik = korisnikController;
            _narudzbe = narudzbe;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var list = new List<ChartModel>{
                new ChartModel { Data = new List<int> { _korisnik.GetAll(null).Count }, Label = "Korisnik", BackgroundColor = "#E74C3C" },
                new ChartModel { Data = new List<int> { _narudzbe.GetAll().Count }, Label = "Narudzbe", BackgroundColor = "#00FF00" },

            };

            _hub.Clients.All.SendAsync("TransferChartData", list);
            return Ok(new { Message = "Request Completed" });
        }
    }
}
