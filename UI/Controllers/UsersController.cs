using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public UsersController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }


        #region Get Users
        public IActionResult GetUsers()
        {
            var users = userManager.Users;
            return View(users);
        }
        #endregion



        #region Details
        public async Task<IActionResult> Details(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                return View(user);
            }

            return RedirectToAction("GetUsers");
        }
        #endregion



        #region Edit

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {

            var user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                return View(user);
            }

            return RedirectToAction("GetUsers");

        }

        [HttpPost]
        public async Task<IActionResult> Edit(IdentityUser model)
        {

            var user = await userManager.FindByIdAsync(model.Id);

            if (user != null)
            {

                user.UserName = model.UserName;
                user.Email = model.UserName;


                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("GetUsers");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                    return RedirectToAction("GetUsers");
                }

            }

            return RedirectToAction("GetUsers");

        }
        #endregion



        #region Delete
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("GetUsers");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(IdentityUser model)
        {

            var user = await userManager.FindByIdAsync(model.Id);

            if (user != null)
            {

                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("GetUsers");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                    return RedirectToAction("GetUsers");
                }

            }

            return RedirectToAction("GetUsers");

        }

        #endregion

    }
}
