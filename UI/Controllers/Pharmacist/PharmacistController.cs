using BLL.Services.NotificationsServices;
using BLL.Services.PharmacistWorkServices;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UI.Controllers.Pharmacist
{
    [Authorize(Roles = "Pharmacist")]
    public class PharmacistController : Controller
    {
        private readonly IPharmacistWorkServices pharmacistWork;
        private readonly INotificationsServices notification;

        public PharmacistController(IPharmacistWorkServices PharmacistWork , INotificationsServices Notification)
        {
            pharmacistWork = PharmacistWork;
            notification = Notification;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WaitingPage()
        {
            notification.Cancel("There are a Treatment Order");
            return View();
        }
        public IActionResult GetAllCompletedOrders()
        {
            return View();
        }
        public IActionResult GetAllOrdersCanceled()
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
            model.DoctorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
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
        public JsonResult NotCancel(int Id)
        {

            var data = pharmacistWork.NotCancel(Id);
            return Json(data);

        }
    }
}
