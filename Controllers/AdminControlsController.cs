using CinemaProject.Data;
using CinemaProject.Models.AdminModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        // GET: AdminControls/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminControls/Create
        public ActionResult Create()
        {
            return View();
        }


        // GET: AdminControls/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        // GET: AdminControls/Delete/5
        public ActionResult Delete(int id)
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
                return Index();
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

    }
}
