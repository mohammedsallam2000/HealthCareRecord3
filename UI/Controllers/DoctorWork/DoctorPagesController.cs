using BLL.Services.LabServices;
using BLL.Services.MedicineServices;
using BLL.Services.PatientServices;
using BLL.Services.RepologeyServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UI.Controllers.DoctorWork
{
    [Authorize]
    public class DoctorPagesController : Controller
    {
        private readonly IPatientServices patient;
        private readonly IMedicineServices medicine;
        private readonly ILabServices lab;
        private readonly IRepologeyServices repologey;

        public DoctorPagesController(IPatientServices patient, IMedicineServices medicine, ILabServices lab, IRepologeyServices repologey)
        {
            this.patient = patient;
            this.medicine = medicine;
            this.lab = lab;
            this.repologey = repologey;
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
        public IActionResult Radiologyprice(string name)
        {
            var med = repologey.GetSalery(name);
            return Json(med);
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
    }
}
