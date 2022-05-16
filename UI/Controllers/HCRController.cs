using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class HCRController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
