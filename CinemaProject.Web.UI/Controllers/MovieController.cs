using CinemaProject.Data.Infrastructure.Context;
using CinemaProject.Data.Models.Entities;
using CinemaProject.Models.MovieModels;
using CinemaProject.Models.Requests.Queries.Requests.Movie;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _data = new ApplicationDbContext();

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            List<MovieViewModel> movies = new();

            foreach (var movie in _data.Movies.ToList())
            {
                MovieViewModel model = new MovieViewModel();

                var sessions = _data.Sessions.Where(x => x.MovieId == movie.MovieId).ToList();

                if (sessions.Any())
                {
                    model.Demonstration = _data.Demonstrations.FirstOrDefault(x => x.DemonstrationId == sessions.FirstOrDefault().DemonstrationId);
                    model.Movie = movie;
                    var start = sessions.Min(x => x.ScreenStart);
                    var end = sessions.Max(x => x.ScreenEnd);

                    model.StartEnd = $"{start.Day} {start.Month} + - {end.Day} {end.Month}";
                    movies.Add(model);
                }


            }
            return View(movies);

        }

        [HttpGet]
        [Route("/Movie/CurrentFilm/{id:int}")]
        public async Task<IActionResult> CurrentFilm(int id)
        {
            var request = new GetMovieByIdQuery
            {
                MovieId = id,
                Includes = new List<string> { "Sessions", "MovieSubcategories" }
            };

            var reponse = await _mediator.Send(request);
            CurentMovieViewModel model = null; 

            if (reponse is not null)
            {
                model = new CurentMovieViewModel(reponse.Movie);

                FillSessionTime(model.SessionTimes);
            }

            return View(model);
        }

        [HttpGet]
        [Route("/Movie/GetTicketSession/{id:int}")]
        public IActionResult GetTicketSession(int id)
        {
            Session session = _data.Sessions.FirstOrDefault(x => x.SessionId == id);
            SeatModelView model = new SeatModelView();
            model.Session = session;

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateSeat(SeatModelView model)
        {

            return View();
        }

        private void FillSessionTime(List<string> list)
        {
            list.Add("10:00");
            list.Add("13:00");
            list.Add("16:00");
            list.Add("19:00");
            list.Add("22:00");
        }
    }
}
