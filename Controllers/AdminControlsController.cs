using CinemaProject.Data;
using CinemaProject.Models.AdminModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
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
            ControlMovies model = new ControlMovies();
            model.Movies = data.Movies.ToList();
            return View(model);
        }

        public IActionResult DeleteMovie()
        {
            return View(data.Movies.ToList());
        }


        [HttpPost]
        [Route("AdminControls/DeleteMovie/{id:int}")]
        public async Task<IActionResult> DeleteMovie(int? id)
        {
            var movie = data.Movies.FirstOrDefault(x => x.MovieId == id);
            if (movie != null)
            {
                data.Movies.Remove(movie);
                var subcategories = data.MovieSubcategories.Where(x => x.MovieId == id);
                foreach (var subcategory in subcategories)
                {
                    data.MovieSubcategories.Remove(subcategory);
                }
                await data.SaveChangesAsync();
            }
            return DeleteMovie();
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
