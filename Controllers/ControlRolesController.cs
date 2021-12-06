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
            
                var newRole = new Role(name);
                


                IdentityResult result = await _roleManager.CreateAsync(newRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        return View(error.Description);

                    }
                }
            }
            return View();

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

        [HttpGet]
        [Route("/ControlRoles/Edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            
            User user = await _userManager.FindByIdAsync(id.ToString());
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
                return Json(new { data = model });
            }

            return NotFound();
        }






        [HttpGet]
        public async Task<ActionResult> GetListRoles()
        {
            List<User> userList = data.Users.ToList();
            List<ChangeRoleViewModel> listChangeRole = new List<ChangeRoleViewModel>();

            if (userList.Count != 0)
            {
                foreach (var user in userList)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var allRoles = _roleManager.Roles.ToList();

                    listChangeRole.Add(new ChangeRoleViewModel
                    {
                        UserId = user.Id.ToString(),
                        UserEmail = user.Email,
                        UserRoles = userRoles,
                        AllRoles = allRoles
                    });

                }
                return Json(new { data = listChangeRole });
            }
            return Json(new { data = "" });
        }



        [HttpPost]
        [Route("/ControlRoles/Edit/{id:int}")]
        public async Task<IActionResult> Edit(int? id, List<string>? roles)
        {
           
            User user = await _userManager.FindByIdAsync(id.ToString());
            user.UserName = user.UserName.Replace(" ",""); 
            if (user != null)
            {

                var userRoles = await _userManager.GetRolesAsync(user);
               
                var allRoles = _roleManager.Roles.ToList();
               
                var addedRoles = roles.Except(userRoles);
              
                var removedRoles = userRoles.Except(roles);

                IdentityResult result = await _userManager.AddToRolesAsync(user, addedRoles);
                await _userManager.RemoveFromRolesAsync(user, removedRoles);
                if (result.Succeeded)
                {
                    return RedirectToAction("ControlUsers", "AdminControls");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        return View(error.Description);

                    }
                }


               

               
            }

            return NotFound();
        }




        public IActionResult UserList() => View(_userManager.Users);

    }
}
