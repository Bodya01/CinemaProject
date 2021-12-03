using CinemaProject.Data;
using CinemaProject.Models.ModelViews;
using CinemaProject.Models.SessionModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CinemaProject.Controllers
{
    public class SessionController : Controller
    {

        private readonly UserManager<User> userManager;

        private readonly SignInManager<User> signInManager;

        ApplicationDbContext data = new();

        public SessionController(UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            
            this.userManager = userManager;

            


            this.signInManager = signInManager;
           
        }


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
        public ActionResult SignIn(User model)
        {
            if (ModelState.IsValid)
            {
             
            }

            return View();
        }


        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(RegisterViewModel model)
        {
            if (ModelState.IsValid & model != null)
            {
                var user = new User
                {
                    UserName = model.Email,
                    UserEmail = model.Email,               
                    UserSurname = model.Surname,
                  
                    
                };
                var result = await userManager.CreateAsync(user, model.Password);
                
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user,  false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }
            }

            return View(model);
        }


        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
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
