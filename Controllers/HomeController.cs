using CinemaProject.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace CinemaProject.Controllers
{
    //[Authorize(Roles = "admin")]

    public class HomeController : Controller
    {
        // GET: HomeController
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext data = new();
        public HomeController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ActionResult> Index()
        {
            User user = await _userManager.GetUserAsync(User);
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetListUsers()
        {
            User user = await _userManager.GetUserAsync(User);
            return Json(new { data = user });
        }

    }
}
