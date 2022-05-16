using BLL.Services.PatientServices;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers.HCRWebsite
{
    public class HCRWebsiteController : Controller
    {
        private readonly IPatientServices patient;

        public HCRWebsiteController(IPatientServices patient)
        {
            this.patient = patient;
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Contacts()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(PatientViewModel model)
        {
            int id = await patient.Add(model);
            if (id > 0)
            {
                ViewBag.Success = 1;
            }
            TempData["model"] = id;
            TempData.Keep();
            return View();
        }
    }
}
