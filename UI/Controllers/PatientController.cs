using BLL.Services.DoctorWork.DoctorPatiant;
using BLL.Services.PatientLabServices;
using BLL.Services.PatientMedicineServices;
using BLL.Services.PatientRediologyServices;
using BLL.Services.PatientServices;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    //[Authorize(Roles = "Receptionist")]
    public class PatientController : Controller
    {
        private readonly IPatientServices patient;
        private readonly IPatientLabServices patientLab;
        private readonly IPatientRediologyServices patientRediology;
        private readonly IPatientMedicineServices patientMedicine;
        private readonly IPatiantDoctor patientData;

        public PatientController(IPatientServices patient, IPatientLabServices patientLab
            , IPatientRediologyServices patientRediology, IPatientMedicineServices patientMedicine, IPatiantDoctor patientData)
        {
            this.patient = patient;
            this.patientLab = patientLab;
            this.patientRediology = patientRediology;
            this.patientMedicine = patientMedicine;
            this.patientData = patientData;
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
            if (id >0)
            {
                ViewBag.Success = 1;
            }
            TempData["model"] = id;
            TempData.Keep();
            return View();
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



        public IActionResult PatientLabDetails(int id)
        {
            ViewBag.id = id;
            var data = patientLab.GetByID(id);
            //var data = patient.GetPatientByID(id);
            return View(data);
        }

        public IActionResult PatientRadiologyDetails(int id)
        {
            var data = patientRediology.GetRediology(id);
            return View(data);
        }

        public IActionResult PatientTreatmentDetails(int id)
        {
            ViewBag.id = id;
            //var data = patientData.GetPatientByID(id);
            return View();
        }

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
