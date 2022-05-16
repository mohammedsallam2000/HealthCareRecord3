using BLL.Services.NotificationsServices;
using BLL.Services.SurgeryDoctorServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers.SurgeryDoctor
{
    public class SurgeryDoctorController : Controller
    {
        private readonly ISurgeryDoctorServices surgeryServ;
        private readonly INotificationsServices notification;

        public SurgeryDoctorController(ISurgeryDoctorServices surgeryServ , INotificationsServices Notification)
        {
            this.surgeryServ = surgeryServ;
            notification = Notification;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WaitingPage()
        {
            notification.Cancel("ther are an suregery");
            return View();
        }

      
        public IActionResult ConfirmOrder(int id)
        {
            surgeryServ.ConfirmOrder(id);
            return RedirectToAction("WaitingPage");
        }

        public JsonResult Cancel(int Id)
        {

            var data = surgeryServ.Cancel(Id);
            return Json(data);

        }
    }
}
