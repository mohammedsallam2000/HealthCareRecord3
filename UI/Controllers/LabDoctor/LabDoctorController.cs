using BLL.Services.LabDoctorWorkServices;
using BLL.Services.PatientServices;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers.LabDoctor
{
    public class LabDoctorController : Controller
    {
        private readonly ILabDoctorWorkServices labDoctorWork;

        public LabDoctorController(ILabDoctorWorkServices LabDoctorWork)
        {
            labDoctorWork = LabDoctorWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WaitingPage()
        {
            return View();
        }

        public IActionResult LabDoctorWork(int Id)
        {
            var Data = labDoctorWork.GetByID(Id);
            return View(Data);
        }

        [HttpPost]
        public async Task<IActionResult> AddResult(LabDoctorWorkViewModel model)
        {
            await labDoctorWork.AddResult(model);
            
            return RedirectToAction("LabDoctorWork", "LabDoctor", new { Id = model.PatientLabId });
        }
    }
}
