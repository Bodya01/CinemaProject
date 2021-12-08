using CinemaProject.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace CinemaProject.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _data = new ApplicationDbContext();


        public MovieController(ApplicationDbContext data)
        {
            _data = data;
        }
        public IActionResult Index()
        {
            var listMovies = _data.Movies.ToList();
            return View(listMovies);
        }





    }
}
