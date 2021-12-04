using CinemaProject.Data;
using System.Collections.Generic;

namespace CinemaProject.Models.AdminModels
{
    public class AddMovie
    {
        public Movie Movies { get; set; }
        public int SubcategoryId { get; set; }
    }
}
