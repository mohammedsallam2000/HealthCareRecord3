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

        #region Create New Patient
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PatientViewModel model)
        {
            int id = await patient.Add(model);
            TempData["model"] = id;
            TempData.Keep();
            return RedirectToAction("Create", "Booking");
        }
        #endregion


        #region Get All Patients
        public IActionResult GetAll(int id)
        {
            var AllPatients = patient.GetAll();
            return View(AllPatients);
        }
        #endregion
    }
}
