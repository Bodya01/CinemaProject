using CinemaProject.Data;

namespace CinemaProject.Models.CartModels
{
    public class CartModelView
    {
        public Product product { get; set; }
        public Ticket ticket { get; set; }
    }
}
