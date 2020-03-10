using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class GameRate : Entity
    {
        //public string GameRateId { get; set; }
        public User User { get; set; }
        public Game Game { get; set; }
        public double Rate { get; set; }
    }
}
