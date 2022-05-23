using BLL.Services.SurgeryServices;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SurgeryController : Controller
    {
        private readonly ISurgeryServices surgery;

        public SurgeryController(ISurgeryServices surgery)
        {
            this.surgery = surgery;
        }
        public IActionResult Index()
        {
            return View();
        }




        public IActionResult AddSurgery()
        {
            ViewBag.Surgery = "";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSurgery(SurgeryViewModel model)
        {
            var result = await surgery.Create(model);
            if (result > 0)
            {
                ViewBag.Surgery = "true";
                return View();
            }
            else
            {
                ViewBag.Surgery = "1";
                return View(model);
            }
        }




        public IActionResult UpdateSurgery(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateSurgery(SurgeryViewModel surgeryvm)
        {
            return View();
        }


        public IActionResult ViewAllSurgery()
        {
            return View();

        }

        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
