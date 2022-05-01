using BLL.Services.DoctorWork.DoctorPatiant;
using BLL.Services.LabServices;
using BLL.Services.MedicineServices;
using BLL.Services.PatientLabServices;
using BLL.Services.PatientMedicineServices;
using BLL.Services.PatientRediologyServices;
using BLL.Services.PatientRoomServices;
using BLL.Services.PatientServices;
using BLL.Services.PatientSurgeryServices;
using BLL.Services.RepologeyServices;
using BLL.Services.RoomServices;
using DAL.Models;
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
        private readonly IPatientMedicineServices patientMedicine;
        private readonly IPatientSurgeryServices patientSurgery;
        private readonly IRoomServices room;
        private readonly IPatientRoomServices patientRoom;

        public DoctorPagesController(IPatiantDoctor patient, IMedicineServices medicine, ILabServices lab, IRepologeyServices repologey, IPatientLabServices  patientLab
            , IPatientRediologyServices patientRediology, IPatientMedicineServices patientMedicine, IPatientSurgeryServices patientSurgery, IRoomServices Room
            , IPatientRoomServices patientRoom)
        {
            this.patient = patient;
            this.medicine = medicine;
            this.lab = lab;
            this.repologey = repologey;
            this.patientLab = patientLab;
            this.patientRediology = patientRediology;
            this.patientMedicine = patientMedicine;
            this.patientSurgery = patientSurgery;
            room = Room;
            this.patientRoom = patientRoom;
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
            return Json(1);
        }
        // Teatment
        [HttpPost]
        public IActionResult sendTreatment(string[] Treatment,string Document, int id)
        {
            var id1 = patientMedicine.Add(Treatment, Document, id);
            return Json(id1);
        }

        // Get Room inFloor sendRoom
        [HttpPost]
        public IActionResult GetRoomInFloor(int floorid)
        {
            var data =room.GetRoomInFloor(floorid);
            
            return Json(data);
        }
        // send sendRoom
        [HttpPost]
        public IActionResult sendRoom(PatientRoomViewModel model)
        {
            
            var data = patientRoom.Create(model);

            return Json(data);
        }
        // Sergery
        [HttpPost]
        public IActionResult sendSergery(string surgeryName,  int id)
        {
            var id1 = patientSurgery.Create(surgeryName,  id);
            return Json(id1);
        }
        [HttpPost]
        public IActionResult Radiologyprice(string name)
        {
            var med = repologey.GetSalery(name);
            return Json(med);
        }
        [HttpPost]
        public IActionResult sendRadiology(string[] Radiology, int id)
        {
            var id1 = patientRediology.Create(Radiology, id);
            return Json(id1);
        }

        public IActionResult GetAllPatientSurgery(int id)
        {
            var data =  patient.GetPatientByID(id);
            return View(data);
        }
        public IActionResult PatientSurgeryDetails(int id)
        {
            var data = patient.GetPatientByID(id);
            return View(data);
        }

        public IActionResult GetAllPatientLab(int id)
        {
            var data = patient.GetPatientByID(id);
            return View(data);
        }
        public IActionResult PatientLabDetails(int id)
        {
            ViewBag.id = id;
            var data=patientLab.GetByID(id);
            //var data = patient.GetPatientByID(id);
            return View(data);
        }
        public IActionResult GetAllPatientRadiology(int id)
        {
            var data = patient.GetPatientByID(id);
            return View(data);
        }
        public IActionResult PatientRadiologyDetails(int id)
        {
            var data = patientRediology.GetRediology(id);
            return View(data);
        }
        public IActionResult GetAllPatientTreatment(int id)
        {
            var data = patient.GetPatientByID(id);
            return View(data);
        }
        public IActionResult PatientTreatmentDetails(int id)
        {
            var data = patient.GetPatientByID(id);
            return View(data);
        }
        public IActionResult GetAllPatientRoom(int id)
        {
            var data = patient.GetPatientByID(id);
            return View(data);
        }
        public IActionResult PatientRoomDetails(int id)
        {
            var data = patient.GetPatientByID(id);
            return View(data);
        }
    }
}
