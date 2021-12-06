using CinemaProject.Data;
using CinemaProject.Models.ModelViews;
using CinemaProject.Models.SessionModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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


        [HttpGet]
        public IActionResult SignIn(string returnUrl = "/Home/Index")
        {

            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {

                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
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
                    UserName = model.UserName,
                    UserEmail = model.Email,
                    UserSurname = model.Surname,
                    UserPhone = model.Phone,



                };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {

            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [AllowAnonymous, HttpGet("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPassword model)
        {
            if (ModelState.IsValid)
            {

                ModelState.Clear();
                model.EmailSent = true;
            }

            return View(model);
        }
    }
}
