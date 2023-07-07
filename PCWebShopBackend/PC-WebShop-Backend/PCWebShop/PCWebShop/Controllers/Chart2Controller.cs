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
    public class Chart2Controller : ControllerBase
    {
        private readonly IHubContext<ChartHub2> _hub;
        private readonly TimerManager _timer;
        private readonly ProizvodController _proizvodi;
        private readonly OglasController _oglasi;
        private readonly PostController _postovi;


        public Chart2Controller(IHubContext<ChartHub2> hub, TimerManager timer, ProizvodController proizvodController,
            OglasController oglasi, PostController postovi)
        {
            _hub = hub;
            _timer = timer;
            _proizvodi = proizvodController;
            _oglasi = oglasi;
            _postovi = postovi;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var list = new List<ChartModel2>{
                new ChartModel2 { Data = new List<int> { _proizvodi.GetAll().Count }, Label = "Proizvodi", BackgroundColor = "#00FF00" },
                new ChartModel2 { Data = new List<int> { _oglasi.GetAll().Count }, Label = "Oglasi", BackgroundColor = "#FFFF00" },
                new ChartModel2 { Data = new List<int> { _postovi.GetAll().Count }, Label = "Postovi", BackgroundColor = " #0000FF" },

            };

            _hub.Clients.All.SendAsync("TransferChartData", list);
            return Ok(new { Message = "Request Completed" });
        }
    }
}
