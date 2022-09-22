using CinemaProject.Data;
using CinemaProject.Models.AdminModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace CinemaProject.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly UserManager<User> _userManager;
        ApplicationDbContext _data = new();
        IWebHostEnvironment _appEnvironment;

        public UserProfileController(UserManager<User> userManager, IWebHostEnvironment appEnvironment, ApplicationDbContext data)
        {
            _userManager = userManager;
            _appEnvironment = appEnvironment;
            _data = data;
        }




        public IActionResult Index() => View(_userManager.Users);
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {

            if (ModelState.IsValid)
            {
                User user = new User { Email = model.UserEmail, UserName = model.UserName, UserSurname = model.UserSurname, UserPhone = model.UserPhone };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
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
        public async Task<IActionResult> Edit(EditUserViewModel model, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {

                    user.UserName = model.UserName.Replace(" ", "");
                    user.UserEmail = model.UserEmail.Replace(" ", "");
                    user.UserSurname = model.UserSurname.Replace(" ", "");
                    user.UserPhone = model.UserPhone.Replace(" ", "");

                    if (uploadedFile != null)
                    {
                        string newPath = @$"\images\user-images\user-{model.Id}\" + uploadedFile.FileName;
                        if (user.PhotoPath != string.Empty & user.PhotoPath != null)
                        {
                            string path = @$"{user.PhotoPath}";

                            FileInfo file = new FileInfo(_appEnvironment.WebRootPath + path);
                            if (file.Exists)
                            {
                                file.Delete();

                                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + newPath, FileMode.Create))
                                {
                                    user.PhotoPath = newPath;
                                    await uploadedFile.CopyToAsync(fileStream);
                                }
                            }
                        }
                        else
                        {
                            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + newPath, FileMode.Create))
                            {
                                user.PhotoPath = newPath;
                                await uploadedFile.CopyToAsync(fileStream);
                            }
                        }
                    }
                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        if (model.Page == "userProfile")
                        {
                            return RedirectToAction("UserInfoProfile", "UserProfile");
                        }

                        return RedirectToAction("ControlUsers", "AdminControls");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return RedirectToAction("ControlUsers", "AdminControls");
        }








        [HttpPost]
        [Route("/UserProfile/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return Content(null);
            }
            else
            {
                User user = await _userManager.FindByIdAsync(id.ToString());
                if (user != null)
                {

                    IdentityResult result = await _userManager.DeleteAsync(user);
                    string pathString = @$"\images\user-images\user-{id}";
                    if (Directory.Exists(pathString))
                    {
                        Directory.Delete(pathString, true);
                    };
                }
                return RedirectToAction("ControlUsers", "AdminControls");
            }

        }

        public static string GetInfoUser()
        {
            MethodBase m = MethodBase.GetCurrentMethod(); ;
            return m.Name.ToString();
        }

        public async Task<IActionResult> UserInfoProfile()
        {
            User user = await _userManager.GetUserAsync(User);
            return View(new EditUserViewModel()
            {
                Id = user.Id.ToString(),
                UserName = user.UserName,
                UserSurname = user.UserSurname,
                UserPhone = user.UserPhone,
                UserEmail = user.UserEmail,
                Page = "userProfile"
            });
        }


        public async Task<IActionResult> EditUserProfile()
        {

            User user = await _userManager.GetUserAsync(User);
            return View(user);
        }





    }

}

