using CinemaProject.Data;
using CinemaProject.Data.Models.Entities;

namespace CinemaProject.Models.CartModels
{
    public class CartModelView
    {
        public Product product { get; set; }
        public Ticket ticket { get; set; }
    }
}
