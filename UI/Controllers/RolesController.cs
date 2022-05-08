using BLL.Services.RolesServices;
using BLL.Services.UsersServices;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IUsersServices users;
        private readonly IRolesServices roles;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IUsersServices users, IRolesServices roles)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.users = users;
            this.roles = roles;
        }

        #region GetRoles
        public IActionResult GetRoles()
        {
            var AllRoles = roles.GetAll();
            return View(AllRoles);
        }
        #endregion


        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model)
        {
            if (await roles.Create(model))
            {
                return RedirectToAction("GetRoles");
            }
            else
            {
                return RedirectToAction("GetRoles");
            }

            //var result = await roleManager.CreateAsync(model);

            //if (result.Succeeded)
            //{
            //    return RedirectToAction("GetRoles");
            //}
            //else
            //{
            //    foreach (var item in result.Errors)
            //    {
            //        ModelState.AddModelError("", item.Description);
            //    }

            //    return RedirectToAction("GetRoles");
            //}
        }
        #endregion

        #region Edit

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {

            var role = await roles.GetByID(id);

            if (role != null)
            {
                return View(role);
            }

            return RedirectToAction("GetRoles");

        }


        [HttpPost]
        public async Task<IActionResult> Edit(IdentityRole model)
        {
            if (await roles.Edit(model))
                return RedirectToAction("GetRoles");
            else
                return View();
            //var role = await roleManager.FindByIdAsync(model.Id);

            //if (role != null)
            //{

            //    role.Name = model.Name;


            //    var result = await roleManager.UpdateAsync(role);

            //    if (result.Succeeded)
            //    {
            //        return RedirectToAction("GetRoles");
            //    }
            //    else
            //    {
            //        foreach (var item in result.Errors)
            //        {
            //            ModelState.AddModelError("", item.Description);
            //        }

            //        return RedirectToAction("GetRoles");
            //    }

            //}

            //return RedirectToAction("GetRoles");


        }
        #endregion

        #region Delete
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {

            var role = await roles.GetByID(id);

            if (role != null)
            {
                return View(role);
            }

            return RedirectToAction("GetRoles");

        }


        [HttpPost]
        public async Task<IActionResult> Delete(IdentityRole model)
        {

            if (await roles.Delete(model.Id))
                return RedirectToAction("GetRoles");
            else
                return View();

            //var role = await roleManager.FindByIdAsync(model.Id);

            //if (role != null)
            //{

            //    var result = await roleManager.DeleteAsync(role);

            //    if (result.Succeeded)
            //    {
            //        return RedirectToAction("GetRoles");
            //    }
            //    else
            //    {
            //        foreach (var item in result.Errors)
            //        {
            //            ModelState.AddModelError("", item.Description);
            //        }

            //        return RedirectToAction("GetRoles");
            //    }

            //}

            //return RedirectToAction("GetRoles");


        }
        #endregion



        #region EditUserInRole

        [HttpGet]
        public async Task<IActionResult> EditUserInRole(string id)
        {

            ViewBag.RoleId = id;
            var role = await roleManager.FindByIdAsync(id);
            if (role != null)
            {
                var model = new List<UserInRoleViewModel>();

                foreach (var user in userManager.Users)
                {
                    var userInRole = new UserInRoleViewModel()
                    {
                        UserId = user.Id,
                        UserName = user.UserName
                    };

                    if (await userManager.IsInRoleAsync(user, role.Name))
                    {
                        userInRole.IsSelected = true;
                    }
                    else
                    {
                        userInRole.IsSelected = false;
                    }

                    model.Add(userInRole);
                }


                return View(model);

            }


            return RedirectToAction("Edit", new { id = role.Id });

        }


        [HttpPost]
        public async Task<IActionResult> EditUserInRole(List<UserInRoleViewModel> model, string id)
        {

            var role = await roleManager.FindByIdAsync(id);

            if (role != null)
            {

                for (int i = 0; i < model.Count; i++)
                {

                    var user = await userManager.FindByIdAsync(model[i].UserId);

                    IdentityResult result = null;

                    if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                    {

                        result = await userManager.AddToRoleAsync(user, role.Name);

                    }
                    else if (!model[i].IsSelected && (await userManager.IsInRoleAsync(user, role.Name)))
                    {
                        result = await userManager.RemoveFromRoleAsync(user, role.Name);
                    }
                    else
                    {
                        continue;
                    }

                }

                return RedirectToAction("Edit", new { id = role.Id });

            }

            return RedirectToAction("Edit", new { id = role.Id });
        }
        #endregion



    }
}
