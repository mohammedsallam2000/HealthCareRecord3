﻿using BLL.Services.NotificationsServices;
using BLL.Services.RadiologyDoctorWorkServices;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UI.Controllers.RadiologyDoctor
{
    [Authorize(Roles = "RadiologyDoctor")]
    public class RadiologyDoctorController : Controller
    {
        private readonly IRadiologyDoctorWorkServices radiologyDoctorWork;
        private readonly INotificationsServices notification;

        public RadiologyDoctorController(IRadiologyDoctorWorkServices RadiologyDoctorWork, INotificationsServices Notification)
        {
            radiologyDoctorWork = RadiologyDoctorWork;
            notification = Notification;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WaitingPage()
        {
            notification.Cancel("There are a Radiology Order");

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
        public IActionResult RadiologyDoctorWork(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        [HttpPost]
        [ActionName("RadiologyDoctorWork")]
        public async Task<IActionResult> AddResult(RadiologyDoctorWorkViewModel model)
        {
            model.DoctorName = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var check = await radiologyDoctorWork.AddResult(model);

            if (check == 1)
            {
                ViewBag.Success = 1;
            }
            ViewBag.Id = model.Id;
            return View();
        }

        public IActionResult EditResults(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditResults(RadiologyDoctorWorkViewModel model)
        {
            model.DoctorName = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var check = await radiologyDoctorWork.AddResult(model);

            if (check == 1)
            {
                ViewBag.Success = 1;
            }
            ViewBag.Id = model.PatientRadiologyId;
            return View(model);
        }

        public JsonResult Cancel(int Id)
        {

            var data = radiologyDoctorWork.Cancel(Id);
            return Json(data);

        }
        public JsonResult NotCancel(int Id)
        {

            var data = radiologyDoctorWork.NotCancel(Id);
            return Json(data);

        }
    }
}
