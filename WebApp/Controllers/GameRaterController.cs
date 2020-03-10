using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using BusinessLogic;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository.Entities;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GameRaterController : ControllerBase
    {

        private readonly ILogger<GameRaterController> _logger;
        private readonly IGameRateManager GameRateManager;

        public GameRaterController(ILogger<GameRaterController> logger, IGameRateManager gameRateManager)
        {
            _logger = logger;
            GameRateManager = gameRateManager;
        }

        [HttpGet]
        public IEnumerable<GameRateModel> GameRates()
        {
            return GameRateManager.GetAllGameRates();
        }

        [Authorize]
        [HttpPost]
        public IActionResult SaveGameRate(UserGameRateModel userRate)
        {
            userRate.UserId =  User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (GameRateManager.SaveGameRate(userRate))
                return Ok();
            else
                return BadRequest();
        }
    }
}
