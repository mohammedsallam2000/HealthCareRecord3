using BLL.Services.RadiologyDoctorWorkServices;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers.RadiologyDoctor
{
    public class RadiologyDoctorController : Controller
    {
        private readonly IRadiologyDoctorWorkServices radiologyDoctorWork;

        public RadiologyDoctorController(IRadiologyDoctorWorkServices RadiologyDoctorWork)
        {
            radiologyDoctorWork = RadiologyDoctorWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WaitingPage()
        {
            return View();
        }
        public IActionResult GetAllCompletedOrders()
        {
            return View();
        }
        public IActionResult RadiologyDoctorWork(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddResult(RadiologyDoctorWorkViewModel model)
        {
            await radiologyDoctorWork.AddResult(model);
            return RedirectToAction("RadiologyDoctorWork", "RadiologyDoctor", new { Id = model.PatientRadiologyId });
        }
    }
}
