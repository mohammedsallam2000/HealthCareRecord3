using BLL.Services.PharmacistWorkServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers.Pharmacist
{
    public class PharmacistController : Controller
    {
        private readonly IPharmacistWorkServices pharmacistWork;

        public PharmacistController(IPharmacistWorkServices PharmacistWork)
        {
            pharmacistWork = PharmacistWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WaitingPage()
        {
            return View();
        }

        public IActionResult PharmacistWork(int Id)
        {
            var Data = pharmacistWork.GetByID(Id);
            pharmacistWork.OrderDetails(Id);
            return View(Data);
        }


    }
}
