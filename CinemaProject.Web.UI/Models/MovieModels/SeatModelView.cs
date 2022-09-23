using CinemaProject.Data;
using CinemaProject.Data.Models.Entities;
using System.Collections.Generic;

namespace CinemaProject.Models.MovieModels
{
    public class SeatModelView
    {

        public ICollection<string> SeaRows { get; set; }

        public Session Session { get; set; }
    }
}
