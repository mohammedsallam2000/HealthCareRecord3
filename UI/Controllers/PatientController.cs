using BLL.Services.PatientServices;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientServices patient;

        public PatientController(IPatientServices patient)
        {
            this.patient = patient;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PatientViewModel patientVM)
        {
            int id = await patient.Add(patientVM);
            TempData["model"] = id;
            TempData.Keep();
            return RedirectToAction("Create","Booking" );
        }
    }
}
