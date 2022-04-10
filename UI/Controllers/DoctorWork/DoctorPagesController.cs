using BLL.Services.DoctorWork.DoctorPatiant;
using BLL.Services.LabServices;
using BLL.Services.MedicineServices;
using BLL.Services.PatientLabServices;
using BLL.Services.PatientRediologyServices;
using BLL.Services.PatientServices;
using BLL.Services.RepologeyServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UI.Controllers.DoctorWork
{
    //[Authorize]
    public class DoctorPagesController : Controller
    {
        private readonly IPatiantDoctor patient;
        private readonly IMedicineServices medicine;
        private readonly ILabServices lab;
        private readonly IRepologeyServices repologey;
        private readonly IPatientLabServices patientLab;
        private readonly IPatientRediologyServices patientRediology;
        public DoctorPagesController(IPatiantDoctor patient, IMedicineServices medicine, ILabServices lab, IRepologeyServices repologey, IPatientLabServices  patientLab
            , IPatientRediologyServices patientRediology)
        {
            this.patient = patient;
            this.medicine = medicine;
            this.lab = lab;
            this.repologey = repologey;
            this.patientLab = patientLab;
            this.patientRediology = patientRediology;
        }
        public IActionResult MyPatiants()
        {
            ViewBag.id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();
        }
        public async Task<IActionResult> DoctorWork(int id)
        {
            var data = await patient.GetByID(id);

            return View(data);
        }
        //Get Prise
        [HttpPost]
        public IActionResult Medicineprice(string name)
        {
            var med = medicine.GetPrie(name);
            return Json(med);
        }
        [HttpPost]
        public IActionResult Labprice(string name)
        {
            var med = lab.Getprice(name);
            return Json(med);
        }
        [HttpPost]
        public IActionResult sendlab(string []Lab,int id)
        {
            var id1 = patientLab.Create(Lab, id);
            return Json(id1);
        }
        [HttpPost]
        [HttpPost]
        public IActionResult Radiologyprice(string name)
        {
            var med = repologey.GetSalery(name);
            return Json(med);
        }
        [HttpPost]
        public IActionResult sendRadiology(string[] Radiology, int id)
        {
            var id1 = patientRediology.Create(Radiology, id, 1);
            return Json(id1);
        }

        public IActionResult GetAllPatientSurgery()
        {
            return View();
        }
        public IActionResult PatientSurgeryDetails()
        {
            return View();
        }

        public IActionResult GetAllPatientLab()
        {
            return View();
        }
        public IActionResult PatientLabDetails()
        {
            return View();
        }
        public IActionResult GetAllPatientRadiology()
        {
            return View();
        }
        public IActionResult PatientRadiologyDetails()
        {
            return View();
        }
        public IActionResult GetAllPatientTreatment()
        {
            return View();
        }
        public IActionResult PatientTreatmentDetails()
        {
            return View();
        }
        public IActionResult GetAllPatientRoom()
        {
            return View();
        }
        public IActionResult PatientRoomDetails()
        {
            return View();
        }
    }
}
