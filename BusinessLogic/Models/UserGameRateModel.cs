using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    public class UserGameRateModel
    {
        public string UserId { get; set; }
        public int GameId { get; set; }
        public byte UserRate { get; set; }
    }
}
