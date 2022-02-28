using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using BLL.Services.NerseServices;

namespace UI.Controllers
{
    public class NurseController : Controller
    {
        public IActionResult AddNurse()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNurse(NurseViewModel nurse)
        {
            return View();
        }

       
    }
}
