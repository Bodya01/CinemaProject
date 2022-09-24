using CinemaProject.Data;
using CinemaProject.Data.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CinemaProject.Models.MovieModels
{
    public class CurentMovieViewModel
    {
        public CurentMovieViewModel() { }

        public CurentMovieViewModel(Movie movie)
        {
            Movie = movie;
            MovieSessions = movie.Sessions.ToList();
            var start = MovieSessions.Min(x => x.ScreenStart);
            var end = MovieSessions.Max(x => x.ScreenEnd);
            Start = $" {start.Day}{start.Month}{start.Year}";
            End = $" {end.Day}{end.Month}{end.Year}";
            TimeDuration = MovieSessions[0].ScreenEnd.Subtract(MovieSessions[0].ScreenStart).ToString();
            MovieSubcategories = string.Join(" ", movie.MovieSubcategories.Select(s => s.SubcategoryId));
        }

        public Movie Movie { get; set; }

        public List<Session> MovieSessions { get; set; }

        public string Start { get; set; }
        public string End { get; set; }

        public string MovieSubcategories { get; set; }

        public string TimeDuration { get; set; }

        public List<string> SessionTimes = new List<string>();
    }
}
