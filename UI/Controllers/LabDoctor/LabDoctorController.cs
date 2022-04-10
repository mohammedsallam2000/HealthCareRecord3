using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers.LabDoctor
{
    public class LabDoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
