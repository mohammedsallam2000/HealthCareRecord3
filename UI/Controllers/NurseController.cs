using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using BLL.Services.NerseServices;

namespace UI.Controllers
{
    public class NurseController : Controller
    {
        NurseServices Nurse=new NurseServices();
        public IActionResult AddNurse()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNurse(NurseViewModel nurse)
        {
            int a = 10;
            int b = 20;

            bool aa=Nurse.Add(nurse);
            return View();
        }

       
    }
}
