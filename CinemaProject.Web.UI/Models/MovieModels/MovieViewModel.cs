using CinemaProject.Data;
using CinemaProject.Data.Models.Entities;

namespace CinemaProject.Models.MovieModels
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }

        public Demonstration Demonstration { get; set; }

        public string StartEnd { get; set; }
    }
}
