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
                return AddMovie();
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

            return View(model);
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
    }
}
