using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controllers
{
    //[Authorize(Roles = "admin")]

    public class HomeController : Controller
    {
        // GET: HomeController

        public ActionResult Index()
        {
            return View();
        }

    }
}
