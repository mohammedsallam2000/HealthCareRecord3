using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers.RadiologyDoctor
{
    public class RadiologyDoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WaitingPage()
        {
            return View();
        }

        public IActionResult RadiologyDoctorWork()
        {
            return View();
        }
    }
}
