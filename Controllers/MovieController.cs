using CinemaProject.Data;
using CinemaProject.Models.MovieModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _data = new ApplicationDbContext();


        public MovieController(ApplicationDbContext data)
        {
            _data = data;
        }

     
        private void FillSessionTime(List<string> list)
        {
            list.Add("10:00");
            list.Add("13:00");
            list.Add("16:00");
            list.Add("19:00");
            list.Add("22:00");
        }


        public IActionResult Index()
        {
            List <MovieViewModel > movies = new();
            
            foreach (var movie in _data.Movies.ToList())
            {
                MovieViewModel model = new MovieViewModel();
               
                var sessions = _data.Sessions.Where(x => x.MovieId == movie.MovieId).ToList();

                if(sessions != null)
                {
                    model.Demonstration = _data.Demonstrations.FirstOrDefault(x => x.DemonstrationId == sessions.FirstOrDefault().DemonstrationId);
                    model.Movie = movie;
                    var start =  sessions.Min(x => x.ScreenStart);
                    var end   =  sessions.Max(x => x.ScreenEnd);
                    
                    model.StartEnd  = $"{start.Day} {start.Month} + - {end.Day} {end.Month}";
                    movies.Add(model);
                }
               
                
            }
            return View(movies);
          
        }
        [HttpGet]
        [Route("/Movie/CurrentFilm/{id:int}")]
        public IActionResult CurrentFilm(int id)
        {
            CurentMovieViewModel model = new CurentMovieViewModel();
            model.Movie = _data.Movies.FirstOrDefault(x=>x.MovieId == id);
            model.MovieSessions = _data.Sessions.Where(x => x.MovieId == model.Movie.MovieId).ToList();
            var start = model.MovieSessions.Min(x => x.ScreenStart);
            var end = model.MovieSessions.Max(x => x.ScreenEnd);
            model.Start = $" {start.Day}{start.Month}{start.Year}";
            model.End = $" {end.Day}{end.Month}{end.Year}";
            model.TimeDuration = model.MovieSessions[0].ScreenEnd.Subtract(model.MovieSessions[0].ScreenStart).ToString();

            FillSessionTime(model.SessionTimes);


            foreach (var item in _data.MovieSubcategories.Where(x => x.MovieId == model.Movie.MovieId).ToList())
            {
                
                model.MovieSubcategories += _data.Subcategories.FirstOrDefault(x => x.SubcategoryId == item.SubcategoryId).SubcategoryName + " ";
            }

          
            return View(model);
        }




        [HttpGet]
        [Route("/Movie/GetTicketSession/{id:int}")]
        public IActionResult GetTicketSession(int id)
        {
            Session  session = _data.Sessions.FirstOrDefault(x => x.SessionId == id);
            SeatModelView model = new SeatModelView();
            model.Session = session;

            return View(model);
        }




        [HttpPost]
        public IActionResult CreateSeat(SeatModelView model)
        {

            return View();
        }


        public IActionResult CheckModel()
        {
            List<SeatModelView> list = new();
            
            return Json(new { data = list });
          
        }

    }
}
