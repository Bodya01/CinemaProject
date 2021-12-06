using CinemaProject.Data;
using CinemaProject.Models.AdminModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.Controllers
{

   
    public class AdminControlsController : Controller
    {
        private ApplicationDbContext data = new ApplicationDbContext();
        private List<Subcategory> subcategories = new List<Subcategory>();

        // GET: AdminControls
        public ActionResult Index()
        {
            return View();
        }

        

        public ActionResult AddMovie()
        {
            GetSubcategoryList();
            ViewBag.Subcategories = new SelectList(subcategories, "SubcategoryId", "SubcategoryName");
            return View();
        }

        [HttpPost]
        public ActionResult AddMovie(AddMovie movie)
        {
            if (ModelState.IsValid & movie != null)
            {
                data.Movies.Add(movie.Movies);
                data.SaveChanges();
                var movieId = data.Movies.FirstOrDefault(x => x.NameMovie == movie.Movies.NameMovie).MovieId;
                data.MovieSubcategories.Add(new MovieSubcategory
                {
                    MovieId = movieId,
                    SubcategoryId = movie.SubcategoryId
                });
                data.SaveChanges();
                return Index();
            }
            return View(movie);
        }

        private void GetSubcategoryList()
        {
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
            
            var list = data.Users.Where(x=> x.Id != Convert.ToInt64(User.Identity.GetUserId())).ToList();
            return Json(new { data = list });
        }


        [HttpGet]
        public ActionResult GetListRoles()
        {
            var list = data.Roles.ToList();
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
