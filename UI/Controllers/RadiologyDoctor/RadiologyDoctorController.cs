using BLL.Services.RadiologyDoctorWorkServices;
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

        public IActionResult RadiologyDoctorWork(int Id)
        {
            ViewBag.Id = Id;
            var Data = radiologyDoctorWork.GetByID(Id);
            return View();
        }
    }
}
