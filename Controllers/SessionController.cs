using CinemaProject.Data;
using CinemaProject.Models.SessionModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CinemaProject.Controllers
{
    public class SessionController : Controller
    {



        // GET: Session
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(User user)
        {

            return View();
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
