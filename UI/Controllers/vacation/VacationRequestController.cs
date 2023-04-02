using BLL.Services._1Vacation.VacationServices.RequestVacationSevice;
using BLL.Services._1Vacation.VacationServices.VacationTypeSevice;
using DAL.Database;
using DAL.Entities;
using DAL.Entities.vacation;
using DAL.Models;
using DAL.Models.vacation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers.vacation
{
    public class VacationRequestController : Controller
    {
        private readonly AplicationDbContext db;
        private readonly IRequestVacationSevice vacation;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public VacationRequestController(AplicationDbContext db, IRequestVacationSevice vacation, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this.vacation = vacation;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        //   VacationRequest/RequestVacation

        public async Task<IActionResult> RequestVacation1()
        {

            var model = await vacation.GetAllAsync();
            return View(model);
        }
        public IActionResult Create()
        {

            ViewBag.Error = "1";
            return View();
        }
        [HttpPost]
        public IActionResult Create(VacationPlainViewModel model, int[]DoyOfWeekCheeked,DateTime a,DateTime aa)
        {
            //Error when use Serves in date
            var data = vacation.Add(model, DoyOfWeekCheeked);
            if (true)
            {
                return RedirectToAction("RequestVacation1");
            }
            return View(model);


        }
        public IActionResult Create1()
        {

            ViewBag.Error = "1";
            return View();
        }
        [HttpPost]
        public IActionResult Create1(vacationPlan model, int[] DoyOfWeekCheeked, DateTime a, DateTime aa)
        {
            //Error when use Serves in date
            var result = db.vacationPlans.Where(x => x.RequestVacation.UserId == model.RequestVacation.UserId &&
           x.VacationDate >= model.RequestVacation.StartDate && x.VacationDate <= model.RequestVacation.EndDate).FirstOrDefault();
            try
            {
                
                for (DateTime date = model.RequestVacation.StartDate; date <= model.RequestVacation.EndDate; date = date.AddDays(1))
                {


                    if (Array.IndexOf(DoyOfWeekCheeked, (int)date.DayOfWeek) != -1)
                    {
                        model.Id = 0;
                        model.VacationDate = date;
                        model.RequestVacation.RequestDate = DateTime.Now;
                        db.vacationPlans.Add(model);
                        db.SaveChanges();



                    }


                }
                ViewBag.Error = "0";
                return View();

            }
            catch (Exception)
            {

                return View(model);
            }

            


        }

        public class Userinfo{
            public string Name { get; set; }
            public string Id { get; set; }
        }
        public async Task<JsonResult> GetUserinRole(string id)
        {
            ViewBag.RoleId = id;
            var role = await roleManager.FindByIdAsync(id);
            
           List<Userinfo>list=new List<Userinfo>();
            if (role != null)
            {
                var model = new List<UserInRoleViewModel>();

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
                        userinfo.Name =await vacation.user(user.Id);
                        userinfo.Id=user.Id;
                        userInRole.IsSelected = true;
                        model.Add(userInRole);
                        list.Add(userinfo);
                    }
                    else
                    {
                        userInRole.IsSelected = false;
                    }
                    
                      
                }


                return Json(list);

            }
            return Json("false");
        }
        public async Task<IActionResult> Updatevacation(int id)
        {

            var data =await vacation.GetByID(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Updatevacation(RequestVacationViewModel model)
        {

            var data = vacation.Update(model);
            if (data == true)
            {
                return RedirectToAction("RequestVacation1");

            }
            else
            {
                return View(model);
            }

        }


        public async Task< IActionResult> Delete(int id)
        {

            var data =await vacation.GetByID(id);

            return View(data);

        }
        [HttpPost]
        public IActionResult Delete(RequestVacationViewModel model)
        {

            var data = vacation.Delete(model.Id);

            if (data == true)
            {
                return RedirectToAction("RequestVacation1");

            }
            else
            {
                return View(model);
            }

        }

    }
}
