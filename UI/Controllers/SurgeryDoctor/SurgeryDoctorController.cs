using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers.SurgeryDoctor
{
    public class SurgeryDoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WaitingPage()
        {
            return View();
        }
    }
}
