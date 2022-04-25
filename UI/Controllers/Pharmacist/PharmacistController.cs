using BLL.Services.PharmacistWorkServices;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers.Pharmacist
{
    public class PharmacistController : Controller
    {
        private readonly IPharmacistWorkServices pharmacistWork;

        public PharmacistController(IPharmacistWorkServices PharmacistWork)
        {
            pharmacistWork = PharmacistWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WaitingPage()
        {
            return View();
        }

        public IActionResult PharmacistWork(int Id)
        {
            ViewBag.Id = Id;
            var Data = pharmacistWork.GetByID(Id);
            pharmacistWork.OrderDetails(Id);
            return View(Data);
        }
        [HttpPost]
        [ActionName("PharmacistWork")]
        public async Task<IActionResult> Done(PharmacistWorkViewModel model)
        {
            var check = await pharmacistWork.Done(model);

            if (check == 1)
            {
                ViewBag.Success = 1;
            }
            ViewBag.Id = model.Id;
            var Data = pharmacistWork.GetByID(model.TreatmentId);
            return View(Data);
        }

        public JsonResult Cancel(int Id)
        {

            var data = pharmacistWork.Cancel(Id);
            return Json(data);

        }
    }
}
