using CinemaProject.Data;

namespace CinemaProject.Models.AdminModels
{
    public class AddMovie
    {
        public Movie Movies { get; set; }
        public int SubcategoryId { get; set; }
    }
}
