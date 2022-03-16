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

namespace UI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IDoctorService Doctor;

        private readonly IReservationServices Reserve;
        private readonly IPatientServices Patient;
        public BookingController(IReservationServices Reserve , IDoctorService Doctor, IPatientServices Patient)
        {
            this.Reserve = Reserve;
            this.Doctor = Doctor;
            this.Patient = Patient;
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
        public JsonResult GetPatintData(PatientViewModel patient)
        {
            int id = (int)TempData["model"];
            TempData["model"] = Patient.GetByID(id);
            var data = Patient.GetByID(id)/*.Where(x => x.DepartmentId == DeptId)*/;
            return Json(data);
        }

        [HttpPost]
        public IActionResult Create(DailyDetectionViewModel Detect)
        {
            var Data = Reserve.Add(Detect);
            return RedirectToAction("Index");
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
