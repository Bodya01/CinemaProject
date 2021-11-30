using CinemaProject.Data;
using CinemaProject.Models.SessionModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CinemaProject.Controllers
{
    public class SessionController : Controller
    {
        ApplicationDbContext data = new();


        // GET: Session
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid & user != null)
            {
                data.Users.Add(user);
                data.SaveChanges();
                return Index();
            }
            return View(user);
        }


        [AllowAnonymous, HttpGet("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPassword model)
        {
            if (ModelState.IsValid)
            {
                //code here 

                ModelState.Clear();
                model.EmailSent = true;
            }

            return View(model);
        }
    }
}
