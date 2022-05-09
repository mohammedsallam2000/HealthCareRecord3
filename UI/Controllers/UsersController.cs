using BLL.Services.UsersServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IUsersServices users;
        public UsersController(UserManager<IdentityUser> userManager, IUsersServices users)
        {
            this.userManager = userManager;
            this.users = users;
        }


        #region Get Users
        public IActionResult GetUsers()
        {
            var AllUsers = users.GetAll();
          
            //var users = userManager.Users;
            return View(AllUsers);
        }
        #endregion



        #region Details
        public async Task<IActionResult> Details(string id)
        {
            var user = await users.GetByID(id);
            

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

            var user = await users.GetByID(id);

            if (user != null)
            {
                return View(user);
            }

            return RedirectToAction("GetUsers");

        }

        [HttpPost]
        public async Task<IActionResult> Edit(IdentityUser model)
        {
            if (await users.Edit(model))
                return RedirectToAction("GetUsers");
            else
                return View();
            //var user = await userManager.FindByIdAsync(model.Id);

            //if (user != null)
            //{

            //    user.UserName = model.UserName;
            //    user.Email = model.UserName;


            //    var result = await userManager.UpdateAsync(user);

            //    if (result.Succeeded)
            //    {
            //        return RedirectToAction("GetUsers");
            //    }
            //    else
            //    {
            //        foreach (var item in result.Errors)
            //        {
            //            ModelState.AddModelError("", item.Description);
            //        }

            //        return RedirectToAction("GetUsers");
            //    }

            //}

            //return RedirectToAction("GetUsers");

        }
        #endregion


        #region Delete
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await users.GetByID(id);
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("GetUsers");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(IdentityUser model)
        {
            if (await users.Delete(model.Id))
                return RedirectToAction("GetUsers");
            else
                return View();
        }
        #endregion
        [AcceptVerbs("GET", "POST")]
        public async Task <IActionResult> VerifyEmail(string email)
        {
            var user= await userManager.FindByEmailAsync(email);

            if (user!=null)
            {
                return Json($"Email {email} is already in use.");
            }

            return Json(true);
        }
        
    }
}
