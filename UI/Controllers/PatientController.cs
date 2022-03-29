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

        #region Patient Profile
        public async Task<IActionResult> Profile(int id)
        {
            var getPatient = await patient.GetByID(id);
            return View(getPatient);
        }
        #endregion

        #region Edit Patient
        [HttpPost]
        public async Task<IActionResult> Edit(PatientViewModel model)
        {
            await patient.Edit(model);
            return RedirectToAction("GetAll", "Patient");
        }
        #endregion
        #region Delete Patient
        [HttpPost]
        public JsonResult Delete(int id)
        {

            var data = patient.Delete(id);

            return Json(data);

        }
        #endregion

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> SSNUssed(string ssn)
        {
            var Ssn = patient.SSNUnUsed(ssn);
            if (Ssn == false)
            {
                return Json($"SSN:  {ssn} is already in use.");
            }

            return Json(true);
        }
    }
}
