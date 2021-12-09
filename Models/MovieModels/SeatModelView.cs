using CinemaProject.Data;
using System.Collections.Generic;

namespace CinemaProject.Models.MovieModels
{
    public class SeatModelView
    {
    
        public ICollection<string> SeaRows { get; set; }

        public Session Session { get; set; }
    }
}
