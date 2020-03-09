using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApp.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class GameRaterController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<GameRaterController> _logger;

        public GameRaterController(ILogger<GameRaterController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<GameRateModel> GameRates()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new GameRateModel
            {
                Title = "Game" + index.ToString(),
                ReleaseDate = new DateTime(2000, rng.Next(1, 12), 2).ToShortDateString(),
                Releaser = "Valaki",
                AvgRating = rng.Next(1, 5)
            })
            .ToArray();
        }
    }
}
