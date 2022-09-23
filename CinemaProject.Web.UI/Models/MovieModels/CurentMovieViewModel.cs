using CinemaProject.Data;
using CinemaProject.Data.Models.Entities;
using System.Collections.Generic;

namespace CinemaProject.Models.MovieModels
{
    public class CurentMovieViewModel
    {

        public Movie Movie { get; set; }

        public List<Session> MovieSessions { get; set; }

        public string Start { get; set; }
        public string End { get; set; }

        public string MovieSubcategories { get; set; }

        public string TimeDuration { get; set; }

        public List<string> SessionTimes = new List<string>();
    }
}
