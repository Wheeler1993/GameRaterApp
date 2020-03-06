using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class GameRate : Entity
    {
        public User User { get; set; }
        public Game Game { get; set; }
    }
}
