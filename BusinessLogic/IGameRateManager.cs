using BusinessLogic.Models;
using Repository;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IGameRateManager
    {
        public double GetGameRating(int gameId);
        public List<GameRateModel> GetAllGameRates();
        public bool SaveGameRate(UserGameRateModel userRate);
    }
}
