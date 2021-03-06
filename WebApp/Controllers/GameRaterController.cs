﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using BusinessLogic;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration Config;

        public GameRaterController(ILogger<GameRaterController> logger, IGameRateManager gameRateManager, IConfiguration config)
        {
            _logger = logger;
            GameRateManager = gameRateManager;
            Config = config;
        }

        [HttpGet]
        public IEnumerable<GameRateModel> GetAllGameRates()
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

        [HttpGet]
        [Authorize]
        public IEnumerable<GameRateModel> GetUserGameRates()
        {
            return GameRateManager.GetUsersGameRates(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

        [HttpGet]
        public GameRateWithDetailsModel GetGameRateWithDetails(int gameId)
        {
            return GameRateManager.GetGameRateWithDetails(gameId);
        }

        [HttpGet]
        public List<GameRateModel> GetGameRatesByReleaser(int releaserId)
        {
            return GameRateManager.GameRatesByReleaser(releaserId);
        }

        [HttpGet]
        public int GetPageSize()
        {
            var size = Config.GetSection("PageSize");
            return int.Parse(size.Value);
        }
    }
}
