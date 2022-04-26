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

        public SurgeryDoctorController(ISurgeryDoctorServices surgeryServ)
        {
            this.surgeryServ = surgeryServ;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WaitingPage()
        {
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
