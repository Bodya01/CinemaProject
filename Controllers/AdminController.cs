using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }


    }
}
