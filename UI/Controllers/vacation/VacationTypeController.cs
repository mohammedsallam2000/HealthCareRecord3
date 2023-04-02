using BLL.Services._1Vacation.VacationServices.VacationTypeSevice;
using DAL.Models.vacation;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.vacation
{
    public class VacationTypeController : Controller
    {
        private readonly IVacationTypeSevice vacation;

        public VacationTypeController(IVacationTypeSevice vacation)
        {
            this.vacation = vacation;
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
        public IActionResult Create(VacationTypeViewModel model)
        {

            var model1 = vacation.Add(model);
            if (model1 == true)
            {
                return RedirectToAction("VacationType");
            }
            else
                ViewBag.Error = "false";

            return View(model);
        }
        public IActionResult Updatevacation(int id)
        {

            var data = vacation.GetByID(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Updatevacation(VacationTypeViewModel model)
        {

            var data = vacation.Update(model);
            if (data == true)
            {
                return RedirectToAction("VacationType");

            }
            else
            {
                return View(model);
            }

        }


        public IActionResult Delete(int id)
        {

            var data = vacation.GetByID(id);

            return View(data);

        }
        [HttpPost]
        public IActionResult Delete(VacationTypeViewModel model)
        {

            var data = vacation.Delete(model.Id);

            return RedirectToAction("VacationType");

        }

    }
}
