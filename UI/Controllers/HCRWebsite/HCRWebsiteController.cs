using BLL.Services.DoctorWork.DoctorPatiant;
using BLL.Services.PatientLabServices;
using BLL.Services.PatientMedicineServices;
using BLL.Services.PatientRediologyServices;
using BLL.Services.PatientServices;
using BLL.Services.ReservationServices;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UI.Hubs;

namespace UI.Controllers.HCRWebsite
{
    public class HCRWebsiteController : Controller
    {
        private readonly IPatientServices patient;
        private readonly IPatientLabServices patientLab;
        private readonly IPatientRediologyServices patientRediology;
        private readonly IPatientMedicineServices patientMedicine;
        private readonly IPatiantDoctor patientData;
        private readonly IReservationServices reserve;
        private readonly IHubContext<RealtimeHub> hub;

        public HCRWebsiteController(IPatientServices patient, IPatientLabServices patientLab
            , IPatientRediologyServices patientRediology, IPatientMedicineServices patientMedicine, IPatiantDoctor patientData, IReservationServices Reserve, IHubContext<RealtimeHub> hub)
        {
            this.patient = patient;
            this.patientLab = patientLab;
            this.patientRediology = patientRediology;
            this.patientMedicine = patientMedicine;
            this.patientData = patientData;
            reserve = Reserve;
            this.hub = hub;
        }
        public IActionResult Home()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Home(DailyDetectionViewModel Detect)
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Detect.PatientId = patient.PatiantId(UserId);
            if (Detect.DateAndTime>DateTime.Now)
            {
              

                var Data = reserve.Add(Detect);
                if (Data != null)
                {
                    ViewBag.Success = 1;
                }
                await hub.Clients.User(Data).SendAsync("newDoctor");
                return View();
            }
            return View(Detect);

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
            if (ModelState.IsValid)
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
            else
            {
                ViewBag.Success = 0;
                return View(model);
            }
        }
        public async Task<IActionResult> PatientProfile(int id)
        {
            var getPatient = await patient.GetByID(id);
            return View(getPatient);
        }
        #region Patient Profile
        public async Task<IActionResult> Profile(int id)
        {
            var getPatient = await patient.GetByID(id);
            return View(getPatient);
        }
        #endregion
        public IActionResult GetAllPatientAnalysis(int id)
        {
            var data = patientData.GetPatientByID(id);
            return View(data);
        }
        public IActionResult PatientLabDetails(int id)
        {
            ViewBag.id = id;
            var data = patientLab.GetByID(id);
            //var data = patient.GetPatientByID(id);
            return View(data);
        }
        public IActionResult GetAllPatientSurgery(int id)
        {
            var data = patientData.GetPatientByID(id);
            return View(data);
        }
        public IActionResult GetAllPatientRadiology(int id)
        {
            var data = patientData.GetPatientByID(id);
            return View(data);
        }
        public IActionResult GetAllPatientTreatment(int id)
        {
            var data = patientData.GetPatientByID(id);
            return View(data);
        }
        public IActionResult GetAllPatientRoom(int id)
        {
            var data = patientData.GetPatientByID(id);
            return View(data);
        }
        public IActionResult PatientRadiologyDetails(int id)
        {
            var data = patientRediology.GetRediology(id);
            return View(data);
        }

        public IActionResult PatientTreatmentDetails(int id, int pataintid)
        {
            ViewBag.id = id;

            var data = patientData.GetPatientByID(pataintid);
            return View(data);
        }
        #region ترجمه
        //Loclization
        public IActionResult SetCulture(string lang ,string URL)
        {
            if (!string.IsNullOrEmpty(lang))
            {
                Response.Cookies.Append(
       CookieRequestCultureProvider.DefaultCookieName,
       CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(lang)),
       new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
   );
            }

            return LocalRedirect(URL);
        }
        #endregion
    }
}
