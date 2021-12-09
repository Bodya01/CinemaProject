using CinemaProject.Data;
using CinemaProject.Models.AdminModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.Controllers
{


    public class AdminControlsController : Controller
    {
        private ApplicationDbContext data = new ApplicationDbContext();
        private List<Subcategory> subcategories = new List<Subcategory>();
        private List<string> sessionTimes = new List<string>();

        [HttpGet]
        public ActionResult GetMovieList()
        {
            var movieList = data.Movies.ToList();
            return Json(new { data = movieList });
        }
        public IActionResult ControlMovies()
        {
            GetSubcategoryList();
            ViewBag.Subcategories = new SelectList(subcategories, "SubcategoryId", "SubcategoryName");
            ControlMovies model = new ControlMovies();
            model.Movies = data.Movies.ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditMovie(ControlMovies movies)
        {
            Movie movie = data.Movies.FirstOrDefault(x => x.MovieId == movies.Id);

            if (movie != null)
            {
                movie.NameMovie = movies.NameMovie;
                movie.AgeRestriction = movies.AgeRestriction;
                movie.CreateAt = DateTime.Parse(movies.CreateAt);
                movie.MovieDescription = movies.MovieDescription;
                movie.MoviePhotoPath = movies.MoviePhotoPath;
                movie.MoviePreviewPath = movies.MoviePreviewPath;
                movie.MovieTrailerPath = movies.MovieTrailerPath;
                data.Movies.Update(movie);

                MovieSubcategory subcategory = data.MovieSubcategories.FirstOrDefault(x => x.MovieId == movies.Id);
                MovieSubcategory newSubcategory = new MovieSubcategory
                {
                    MovieSubcategoriesId = subcategory.MovieSubcategoriesId,
                    MovieId = subcategory.MovieId,
                    SubcategoryId = movies.SubcategoryId
                };
                data.MovieSubcategories.Remove(subcategory);
                data.MovieSubcategories.Add(newSubcategory);

                await data.SaveChangesAsync();
            }
            return RedirectToAction("ControlMovies", "AdminControls");
        }

        [HttpPost]
        [Route("AdminControls/DeleteMovie/{id:int}")]
        public async Task<IActionResult> DeleteMovie(int? id)
        {
            var movie = data.Movies.FirstOrDefault(x => x.MovieId == id);
            if (movie != null)
            {
                data.Movies.Remove(movie);
                foreach (var subcategory in data.MovieSubcategories.Where(x => x.MovieId == id))
                {
                    data.MovieSubcategories.Remove(subcategory);
                }
                await data.SaveChangesAsync();
            }
            return RedirectToAction("ControlMovies", "AdminControls");
        }

        public ActionResult AddMovie()
        {
            GetSubcategoryList();
            ViewBag.Subcategories = new SelectList(subcategories, "SubcategoryId", "SubcategoryName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(AddMovie movie)
        {
            if (ModelState.IsValid & movie != null)
            {
                await data.Movies.AddAsync(movie.Movies);
                await data.SaveChangesAsync();
                var movieId = data.Movies.OrderBy(x => x.MovieId).Last().MovieId;
                await data.MovieSubcategories.AddAsync(new MovieSubcategory
                {
                    MovieId = movieId,
                    SubcategoryId = movie.SubcategoryId
                });
                await data.SaveChangesAsync();
                return RedirectToAction("ControlMovies", "AdminControls");
            }
            return View(movie);
        }

        private void GetSubcategoryList()
        {
            subcategories = data.Subcategories.ToList();
        }
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                await data.Products.AddAsync(model);
                await data.SaveChangesAsync();
            }

            return RedirectToAction("ControlProducts", "AdminControls");
        }

        public IActionResult ControlProducts()
        {
            GetProductList();
            ControlProducts controlProducts = new ControlProducts();
            controlProducts.Products = data.Products.ToList();
            return View(controlProducts);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(ControlProducts model)
        {
            if(model != null)
            {
                data.Remove(data.Products.FirstOrDefault(x => x.ProductId == model.ProductId));
                await data.SaveChangesAsync();
            }

            return RedirectToAction("ControlProducts", "AdminControls");
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ControlProducts model)
        {
            if (model != null)
            {
                Product product = data.Products.FirstOrDefault(x => x.ProductId == model.ProductId);
                product.ProductName = model.ProductName;
                product.ProductPrice = model.ProductPrice;
                product.ProductPhotoPath = model.ProductPhotoPath;
                data.Update(product);
                await data.SaveChangesAsync();
            }

            return RedirectToAction("ControlProducts", "AdminControls");
        }

        [HttpGet]
        public ActionResult GetProductList()
        {
            var productList = data.Products.ToList();
            return Json(new { data = productList });
        }


        [HttpGet]
        public ActionResult GetListUsers()
        {
            var list = data.Users.Where(x => x.Id != Convert.ToInt64(User.Identity.GetUserId())).ToList();
            return Json(new { data = list });
        }
        public IActionResult ControlUsers()
        {
            EditUserViewModel model = new EditUserViewModel();
            model.Users = data.Users.ToList();
            return View(model);
        }
        public IActionResult AddSession()
        {
            FillSessionTime();
            ViewBag.SessionTimes = new SelectList(sessionTimes);
            ViewBag.Demonstrations = new SelectList(data.Demonstrations.ToList(), "DemonstrationId", "DemonstrationName");
            ViewBag.Halls = new SelectList(data.Halls.ToList(), "HallId", "HallName");
            ViewBag.Movies = new SelectList(data.Movies.ToList(), "MovieId", "NameMovie");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSession(AddSession newSession)
        {
            if (newSession != null)
            {
                Session session = new Session
                {
                    CinemaId = newSession.CinamaId,
                    DemonstrationId = newSession.DemonstrationId,
                    HallId = newSession.HallId,
                    MovieId = newSession.MovieId,
                    ScreenStart = DateTime.Parse($"{newSession.SessionDate} {newSession.SessionTime}"),
                    ScreenEnd = GetSessionEndTime(newSession.SessionDate, newSession.SessionTime, newSession.SessionLasts),
                    Hall = data.Halls.FirstOrDefault(x => x.HallId == newSession.HallId),
                    Demonstration = data.Demonstrations.FirstOrDefault(x => x.DemonstrationId == newSession.DemonstrationId),
                    Movie = data.Movies.FirstOrDefault(x => x.MovieId == newSession.MovieId)
                };
                data.Sessions.Add(session);
                await data.SaveChangesAsync();
                return RedirectToAction("ControlSessions", "AdminControls");
            }
            return View();
        }
        private DateTime GetSessionEndTime(string dateStart, string timeStart, string lastTime)
        {
            string temp = string.Empty;
            string newTimeStart = "0";
            for (int i = 0; i < timeStart.Length - 1; i++)
            {
                newTimeStart += lastTime[i];
            }
            for (int i = 0; i < timeStart.Length; i++)
            {
                if (!char.IsDigit(timeStart[i]))
                {
                    temp += timeStart[i];
                    continue;
                }
                temp += ((timeStart[i] - '0') + (newTimeStart[i] - '0')).ToString();
            }
            return DateTime.Parse($"{ dateStart} {temp}");
        }
        private void FillSessionTime()
        {
            sessionTimes.Add("10:00");
            sessionTimes.Add("13:00");
            sessionTimes.Add("16:00");
            sessionTimes.Add("19:00");
            sessionTimes.Add("22:00");
        }
        public ActionResult GetSessionList()
        {
            var sessionList = data.Sessions.ToList();
            return Json(new { data = sessionList });
        }
        public IActionResult ControlSessions()
        {
            FillSessionTime();
            ViewBag.SessionTimes = new SelectList(sessionTimes);
            ViewBag.Demonstrations = new SelectList(data.Demonstrations.ToList(), "DemonstrationId", "DemonstrationName");
            ViewBag.Halls = new SelectList(data.Halls.ToList(), "HallId", "HallName");
            ViewBag.Movies = new SelectList(data.Movies.ToList(), "MovieId", "NameMovie");
            ControlSessions model = new ControlSessions();
            model.Sessions = data.Sessions.ToList();
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> EditSession(ControlSessions model)
        {
            Session session = data.Sessions.FirstOrDefault(x => x.SessionId == model.SessionId);
            if (session != null)
            {
                Session newSession = new Session
                {
                    SessionId = model.SessionId,
                    DemonstrationId = model.DemonstrationId,
                    Demonstration = data.Demonstrations.FirstOrDefault(x => x.DemonstrationId == model.DemonstrationId),
                    HallId = model.HallId,
                    Hall = data.Halls.FirstOrDefault(x => x.HallId == model.HallId),
                    MovieId = model.MovieId,
                    Movie = data.Movies.FirstOrDefault(x => x.MovieId == model.MovieId),
                    CinemaId = model.CinemaId,
                    ScreenEnd = DateTime.Parse(model.SessionEnds),
                    ScreenStart = DateTime.Parse(model.SessionDate),
                };
                data.Sessions.Remove(session);
                await data.Sessions.AddAsync(newSession);
                await data.SaveChangesAsync();
            }
            return RedirectToAction("ControlSessions", "AdminControls");
        }

        [HttpPost]
        [Route("AdminControls/DeleteSession/{id:int}")]
        public async Task<IActionResult> DeleteSession(int? id)
        {
            var session = data.Sessions.FirstOrDefault(x => x.SessionId == id);
            if (session != null)
            {
                data.Sessions.Remove(session);
                await data.SaveChangesAsync();
            }
            return RedirectToAction("ControlSessions", "AdminControls");
        }
    }
}
