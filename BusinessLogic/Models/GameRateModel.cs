using System;

namespace BusinessLogic.Models
{
    public class GameRateModel
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string Releaser { get; set; }
        public int ReleaserId { get; set; }
        public string Cover { get; set; }
        public double AvgRating { get; set; }
    }
}
