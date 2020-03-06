using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class Game : Entity
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Releaser { get; set; }
        public string Cover { get; set; }
        public double AvgRating { get; set; }
    }
}
