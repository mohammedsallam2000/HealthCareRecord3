﻿using BLL.Services.DoctorWork.DoctorPatiant;
using BLL.Services.LabServices;
using BLL.Services.MedicineServices;
using BLL.Services.NotificationsServices;
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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UI.Hubs;

namespace UI.Controllers.DoctorWork
{
    [Authorize(Roles ="Doctor")]
    public class DoctorPagesController : Controller
    {
        
        private readonly IPatiantDoctor patient;
        private readonly INotificationsServices notification;
        private readonly IMedicineServices medicine;
        private readonly ILabServices lab;
        private readonly IRepologeyServices repologey;
        private readonly IPatientLabServices patientLab;
        private readonly IPatientRediologyServices patientRediology;
        private readonly IPatientMedicineServices patientMedicine;
        private readonly IPatientSurgeryServices patientSurgery;
        private readonly IRoomServices room;
        private readonly IPatientRoomServices patientRoom;
        private readonly IHubContext<RealtimeHub> hubContext;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public DoctorPagesController(IPatiantDoctor patient,INotificationsServices Notification, IMedicineServices medicine, ILabServices lab, IRepologeyServices repologey, IPatientLabServices  patientLab
            , IPatientRediologyServices patientRediology, IPatientMedicineServices patientMedicine, IPatientSurgeryServices patientSurgery, IRoomServices Room
            , IPatientRoomServices patientRoom , IHubContext<RealtimeHub> hubContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            this.patient = patient;
            this.notification = Notification;
            this.medicine = medicine;
            this.lab = lab;
            this.repologey = repologey;
            this.patientLab = patientLab;
            this.patientRediology = patientRediology;
            this.patientMedicine = patientMedicine;
            this.patientSurgery = patientSurgery;
            this.room = Room;
            this.patientRoom = patientRoom;
            this.hubContext = hubContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
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
        public IActionResult GetAllLab(string name)
        {
            var med = lab.Getprice(name);
            return Json(med);
        }
        [HttpPost]
        public async Task <IActionResult> sendlab(string []Lab,int id)
        {
            var id1 = patientLab.Create(Lab, id);
            if (id1==0)
            {
                // Send to User In Doctor Role
                var AnalysisDoctor = await userManager.GetUsersInRoleAsync("AnalysisDoctor");
                var userid = AnalysisDoctor.Select(x => x.Id);
                // Real Time Send Analysis
                notification.Confirm("There are an Analysis Order");
                await hubContext.Clients.Users(userid).SendAsync("GetNewlab");
                return Json(1);
            }
            return Json(0);
        }
        // Teatment
        [HttpPost]
        public async Task<IActionResult> sendTreatment(string[] Treatment,string[] Detailes, int id)
        {
           
            var id1 = patientMedicine.Add(Treatment, Detailes, id);
            // Real Time Send Treatment
            var Pharmacist = await userManager.GetUsersInRoleAsync("Pharmacist");
            var userid = Pharmacist.Select(x => x.Id);
            notification.Confirm("TThere are a Treatment Order");
            await hubContext.Clients.Users(userid).SendAsync("GetNewTreatment");
            return Json(id1);
        }

        // Get Room inFloor sendRoom
        [HttpPost]
        public IActionResult GetRoomInFloor(int floorid)
        {
            var data =room.GetRoomsInFloor(floorid);
            
            return Json(data);
        }
        // send sendRoom
        [HttpPost]
        public async Task< IActionResult> sendRoom(PatientRoomViewModel model)
        {
            notification.Confirm("There are a Room order");
            var data = patientRoom.Create(model);

            await hubContext.Clients.All.SendAsync("GetNewRoom");
            return Json(data);
        }
        // Sergery
        [HttpPost]
        public async Task< IActionResult> sendSergery(string surgeryName,  int id)
        {

            var id1 = patientSurgery.Create(surgeryName,  id);
            notification.Confirm("There are a surgery order");
            await hubContext.Clients.All.SendAsync("GetNewSergery");
            return Json(id1);
        }
        [HttpPost]
        public IActionResult Radiologyprice(string name)
        {
            var med = repologey.GetSalery(name);
            return Json(med);
        }
        [HttpPost]
        public async Task<IActionResult> sendRadiology(string[] Radiology, int id)
        {
            var id1 = patientRediology.Create(Radiology, id);
            if (id1 == 1)
            {
                var RadiologyDoctor = await userManager.GetUsersInRoleAsync("RadiologyDoctor");
                var userid = RadiologyDoctor.Select(x => x.Id);
                // Real Time Send Rediology
                notification.Confirm("There are a Radiology Order");
                await hubContext.Clients.Users(userid).SendAsync("GetNewRadiology", "Hi this is New Radiology");
                return Json(1);
            }
            return Json(0);
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
        public IActionResult PatientTreatmentDetails(int id,int pataintid)
        {
            ViewBag.id=id;
            
            var data = patient.GetPatientByID(pataintid);
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
        // Finsh Doctor Pataint
        public IActionResult Finsh(int id)
        {
            var data = patient.FinshPataiant(id);
            return RedirectToAction("MyPatiants");
        }
    }
}
