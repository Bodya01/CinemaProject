using CinemaProject.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CinemaProject.Controllers
{
    public class AdminControlsController : Controller
    {
        private ApplicationDbContext data = new ApplicationDbContext();
        private List<Subcategory> Subcategories = new List<Subcategory>();

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
            return View();
        }

        [HttpPost]
        public ActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid & movie != null)
            {
                data.Movies.Add(movie);
                data.SaveChanges();
                return Index();
            }
            return View(movie);
        }

       
    }
}
