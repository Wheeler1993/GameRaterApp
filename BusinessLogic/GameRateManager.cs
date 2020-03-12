﻿using Repository;
using System.Linq;
using System;
using System.Collections.Generic;
using BusinessLogic.Models;
using Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic
{
    public class GameRateManager : IGameRateManager
    {
        GameRaterDbContext DbContext;
        public GameRateManager(GameRaterDbContext gameRaterDbContext)
        {
            DbContext = gameRaterDbContext;
        }
        public double GetGameRating(int gameId)
        {
            double rate = DbContext.GamesRates.Where(rate => rate.Game.Id == gameId).Average(rate => rate.Rate);
            return rate;
        }

        public List<GameRateModel> GetAllGameRates()
        {
            List<GameRateModel> rates = DbContext.Games.Select(game => new GameRateModel()
            {
                GameId = game.Id,
                Title = game.Title,
                Cover = game.Cover,
                ReleaseDate = game.ReleaseDate.ToShortDateString(),
                Releaser = game.Releaser.Name,
                ReleaserId = game.Releaser.Id,
                AvgRating = game.Rates.Average(rate => rate.Rate)
            }).ToList();
            return rates;
        }

        public bool SaveGameRate(UserGameRateModel userRate)
        {
            GameRate userRateEntity = DbContext.GamesRates.Where(rate => rate.Game.Id == userRate.GameId && rate.User.Id == userRate.UserId).FirstOrDefault();
            if (userRateEntity != null)
                userRateEntity.Rate = userRate.UserRate;
            else
                DbContext.GamesRates.Add(new GameRate() { Game = DbContext.Games.Find(userRate.GameId), User = DbContext.Users.Find(userRate.UserId), Rate = userRate.UserRate });
            if (DbContext.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public List<GameRateModel> GetUsersGameRates(string userId)
        {
            List<GameRateModel> userRates = DbContext.GamesRates.Where(rate => rate.User.Id == userId)
                .Select(rate => new GameRateModel() { GameId=rate.Game.Id, Title = rate.Game.Title, Cover=rate.Game.Cover, ReleaseDate=rate.Game.ReleaseDate.ToShortDateString(), Releaser=rate.Game.Releaser.Name, ReleaserId=rate.Game.Releaser.Id, AvgRating=rate.Rate }).ToList();
            return userRates;
        }

        public GameRateWithDetailsModel GetGameRateWithDetails(int gameId)
        {
            return DbContext.Games.Where(game => game.Id == gameId).Select(game => new GameRateWithDetailsModel() { GameId = game.Id, Title = game.Title, Cover=game.Cover, ReleaseDate = game.ReleaseDate.ToShortDateString(), Releaser = game.Releaser.Name, ReleaserId=game.Releaser.Id, AvgRating = game.Rates.Average(rate => rate.Rate), Details=game.Details }).FirstOrDefault();
        }

        public List<GameRateModel> GameRatesByReleaser(int releaserId)
        {
            return DbContext.Games.Where(game => game.Releaser.Id == releaserId).Select(game => new GameRateModel()
            {
                GameId = game.Id,
                Title = game.Title,
                Cover = game.Cover,
                ReleaseDate = game.ReleaseDate.ToShortDateString(),
                Releaser = game.Releaser.Name,
                ReleaserId = game.Releaser.Id,
                AvgRating = game.Rates.Average(rate => rate.Rate)
            }).ToList();
        }
    }
}
