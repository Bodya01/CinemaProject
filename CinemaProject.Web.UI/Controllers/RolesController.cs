using CinemaProject.Data;
using CinemaProject.Data.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controllers
{
    public class RolesController : Controller
    {
        ApplicationDbContext _data = new ApplicationDbContext();

        public IActionResult Index() => View(_data.Roles);


        public IActionResult Create() => View();
        //    [HttpPost]
        //    public async Task<IActionResult> Create(string name)
        //    {
        //        if (!string.IsNullOrEmpty(name))
        //        {
        //            IdentityResult result = await _data.Roles.CreateAsync(new IdentityRole(name));
        //            if (result.Succeeded)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //            else
        //            {
        //                foreach (var error in result.Errors)
        //                {
        //                    ModelState.AddModelError(string.Empty, error.Description);
        //                }
        //            }
        //        }
        //        return View(name);
        //    }


    }
}
