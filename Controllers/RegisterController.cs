using CinemaProject.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controllers
{
    public class RegisterController : Controller
    {
        ApplicationDbContext data = new();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            if (ModelState.IsValid & user != null)
            {
                data.Users.Add(user);
                data.SaveChanges();
                return Index();
            }

            return View(user);
        }
    }
}
