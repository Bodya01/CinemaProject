﻿using CinemaProject.Data;
using CinemaProject.Models.AdminModels;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CinemaProject.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly UserManager<User> _userManager;
        
        public UserProfileController(UserManager<User> userManager)
        {
            _userManager = userManager;
            
        }

        public IActionResult Index() => View(_userManager.Users);
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {

            if (ModelState.IsValid)
            {
                User user = new User { Email = model.UserEmail, UserName = model.UserName, UserSurname = model.UserSurname,UserPhone = model.UserPhone };
                
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
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                  
                    user.UserName = model.UserName.Trim();
                    user.UserEmail = model.UserEmail;
                    user.UserSurname = model.UserSurname;
                    user.UserPhone = model.UserPhone;

                    var result = await _userManager.UpdateAsync(user);
                  
                    if (result.Succeeded)
                    {
                        return RedirectToAction("ControlUsers","AdminControls");
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
                }
                return RedirectToAction("ControlUsers", "AdminControls");
            }

        }

        public static string GetInfoUser()
        {
            MethodBase m = MethodBase.GetCurrentMethod(); ;
            return m.Name.ToString();
        }



    }

}

