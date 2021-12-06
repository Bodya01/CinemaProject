using CinemaProject.Data;
using CinemaProject.Models.AdminModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace CinemaProject.Controllers
{
    public class ControlRolesController : Controller
    {
        ApplicationDbContext data = new ApplicationDbContext();
        RoleManager<Role> _roleManager;
        UserManager<User> _userManager;
        public ControlRolesController(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index() => View(_roleManager.Roles);


        public IActionResult CreateRole() => View();
        [HttpPost]
        public async Task<IActionResult> CreateRole(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new Role(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(name);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            Role role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Edit(string userId)
        {
            
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
               
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = user.Id.ToString(),
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }



        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
           
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                
                var userRoles = await _userManager.GetRolesAsync(user);
               
                var allRoles = _roleManager.Roles.ToList();
                
                var addedRoles = roles.Except(userRoles);
               
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("UserList");
            }

            return NotFound();
        }




        public IActionResult UserList() => View(_userManager.Users);

    }
}
