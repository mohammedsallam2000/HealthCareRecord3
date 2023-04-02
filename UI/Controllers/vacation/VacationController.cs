using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using BLL.Services._1Vacation.VacationServices;
using BLL.Services._1Vacation.VacationServices.RequestVacationSevice;
using BLL.Services._1Vacation.VacationServices.UserVacation;
using DAL.Models;
using DAL.Models.vacation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.vacation
{
    [Authorize(Roles = "SupAdmin")]
   

    public class VacationController : Controller
    {
        private readonly IVacationServices vacation;
        private readonly IUserVacation user;
        private readonly IRequestVacationSevice vacation1;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public VacationController(IVacationServices vacation,IUserVacation user,IRequestVacationSevice vacation1, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.vacation = vacation;
            this.user = user;
            this.vacation1 = vacation1;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public IActionResult index()

        {
            return View();
        }
        public IActionResult GetVacationReportPlain()

        {
            ViewBag.check = "0";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetVacationReportPlain(UserVacationSum model)

        {
            if (model.DepartmentId ==null)
            {
                ModelState.AddModelError("", "Depatment id Requierd");
            }
            else
            {
                ViewBag.check = "1";
                var role = await roleManager.FindByIdAsync(model.DepartmentId);
                List<string> name = new List<string>();
                List<Userinfo> list = new List<Userinfo>();
                if (role != null)
                {


                    foreach (var user in userManager.Users)
                    {
                        Userinfo userinfo = new Userinfo();

                        var userInRole = new UserInRoleViewModel()
                        {
                            UserId = user.Id,
                            UserName = user.UserName,

                        };

                        if (await userManager.IsInRoleAsync(user, role.Name))
                        {
                            userinfo.Name = await vacation1.user(user.Id);
                            name.Add(userinfo.Name);
                            //userInRole.IsSelected = true;
                            //model1.Add(userInRole);
                            //list.Add(userinfo);
                        }



                    }




                }
                var data = await user.GetAll(model, name);
                return View(data);


            }


            
           

            return View(model);
        }
        public IActionResult VacationType()
        {

            var model = vacation.GetAll();
            return View(model);
        }
        public IActionResult Create()
        {

            
                return View();
        }
        [HttpPost]
        public IActionResult Create(VacationPlainViewModel model)
        {

            var model1 = vacation.Add(model);
            if (model1==true)
            {
                return RedirectToAction("VacationType");
            }else
            return View(model);
        }
        public IActionResult Updatevacation(int id)
        {

            var data = vacation.GetByID(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult UpdateLab(VacationPlainViewModel model)
        {

            var data = vacation.Update(model);
            if (data == true)
            {
                return RedirectToAction("ViewAllLab");

            }
            else
            {
                return View(model);
            }

        }
       
       

        public JsonResult Delete(int id)
        {

            var data = vacation.Cancel(id);

            return Json(data);

        }

    }
}
