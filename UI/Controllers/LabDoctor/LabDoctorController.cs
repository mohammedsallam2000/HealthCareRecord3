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
        public IActionResult GetAllCompletedOrders()
        {
            return View();
        }
        public IActionResult LabDoctorWork(int Id)
        {     
            var Data = labDoctorWork.GetByID(Id);
            return View(Data);
        }

        [HttpPost]
        [ActionName("LabDoctorWork")]
        public async Task<IActionResult> AddResult(LabDoctorWorkViewModel model)
        {
            var check = await labDoctorWork.AddResult(model);
            
            if (check==1)
            {
                ViewBag.Success = 1;
            }

            var Data = labDoctorWork.GetByID(model.PatientLabId);
            return View(Data);
        }

        public IActionResult EditResults(int Id)
        {
            var Data = labDoctorWork.GetByID(Id);
            return View(Data);
        }

        [HttpPost]
        public async Task<IActionResult> EditResults(LabDoctorWorkViewModel model)
        {
            var check = await labDoctorWork.AddResult(model);

            if (check == 1)
            {
                ViewBag.Success = 1;
            }

            var Data = labDoctorWork.GetByID(model.PatientLabId);
            return View(Data);
        }
    }
}
