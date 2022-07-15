using BLL.Services.LabDoctorWorkServices;
using BLL.Services.NotificationsServices;
using BLL.Services.PatientServices;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UI.Controllers.LabDoctor
{
    [Authorize(Roles = "AnalysisDoctor")]
    public class LabDoctorController : Controller
    {
        private readonly ILabDoctorWorkServices labDoctorWork;
        private readonly INotificationsServices notification;

        public LabDoctorController(ILabDoctorWorkServices LabDoctorWork, INotificationsServices Notification)
        {
            labDoctorWork = LabDoctorWork;
            notification = Notification;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WaitingPage()
        {
            notification.Cancel("There are an Analysis Order");

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
        public IActionResult LabDoctorWork(int Id)
        {     
            var Data = labDoctorWork.GetByID(Id);
            return View(Data);
        }

        [HttpPost]
        [ActionName("LabDoctorWork")]
        public async Task<IActionResult> AddResult(LabDoctorWorkViewModel model)
        {
            model.AnalysisDoctorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var check = await labDoctorWork.AddResult(model);
            
            if (check==1)
            {
                ViewBag.Success = 1;
            }

            var Data = labDoctorWork.GetByID(model.PatientLabId);
            return View(Data);
        }

        public IActionResult EditResults(int Id)
        {
            var Data = labDoctorWork.GetByID(Id);
            return View(Data);
        }

        [HttpPost]
        public async Task<IActionResult> EditResults(LabDoctorWorkViewModel model)
        {
            model.AnalysisDoctorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var check = await labDoctorWork.AddResult(model);

            if (check == 1)
            {
                ViewBag.Success = 1;
            }

            var Data = labDoctorWork.GetByID(model.PatientLabId);
            return View(Data);
        }

        public JsonResult Cancel(int Id)
        {

            var data = labDoctorWork.Cancel(Id);
            return Json(data);

        }
        public JsonResult NotCancel(int Id)
        {

            var data = labDoctorWork.NotCancel(Id);
            return Json(data);

        }
    }
}
