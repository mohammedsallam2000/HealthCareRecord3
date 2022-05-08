using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL.Models;
using BLL.Services.ReservationServices;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using BLL.Services;
using BLL.Services.PatientServices;
using Microsoft.AspNetCore.SignalR;
using UI.Hubs;
using Microsoft.AspNetCore.Authorization;

namespace UI.Controllers
{
    //[Authorize(Roles = "Receptionist")]
    public class BookingController : Controller
    {
        private readonly IDoctorService Doctor;

        private readonly IReservationServices Reserve;
        private readonly IPatientServices Patient;
        private readonly IHubContext<RealtimeHub> hub;

        public BookingController(IReservationServices Reserve , IDoctorService Doctor, IPatientServices Patient,IHubContext<RealtimeHub> hub)
        {
            this.Reserve = Reserve;
            this.Doctor = Doctor;
            this.Patient = Patient;
            this.hub = hub;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetPatintData(string SSN)
        {
            //int id = (int)TempData["model"];
            //TempData["model"] = Patient.GetBySSN(SSN);
            var data = Patient.GetBySSN(SSN);
            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DailyDetectionViewModel Detect)
        {
            var Data = Reserve.Add(Detect);
            await hub.Clients.User(Data).SendAsync("newDoctor");
            return View();
        }

        //------------------ajax----------------------------------------------
        [HttpPost]
        public JsonResult GetDoctorByDepartmentID(int DeptId , int ShiftId)
        {
            var doctorData = Doctor.GetAll(DeptId , ShiftId);
            return Json(doctorData);
        }
    }
}
