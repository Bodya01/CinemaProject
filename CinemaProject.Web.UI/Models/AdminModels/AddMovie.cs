using CinemaProject.Data;
using CinemaProject.Data.Models.Entities;

namespace CinemaProject.Models.AdminModels
{
    public class AddMovie
    {
        public Movie Movies { get; set; }
        public int SubcategoryId { get; set; }
    }
}
