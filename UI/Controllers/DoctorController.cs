using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService Doctor;
        public DoctorController(IDoctorService Doctor)
        {

            this.Doctor = Doctor;
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
        public async Task<IActionResult> Create(DoctorViewModel doc)
        {
            if (ModelState.IsValid)
            {
                var check = await Doctor.Add(doc);
                if (check != 0)
                {
                    ViewBag.Success = 1;
                }
                return View();
            }

            
            return View();

        }

        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditAccountInfo(DoctorViewModel doc)
        {
            await Doctor.UpdateAccountInfo(doc);
             return RedirectToAction("GetAllDoctor", "Doctor");        
        }
        [HttpPost]
        public async Task<IActionResult> EditBasicInfo(DoctorViewModel doc)
        {
            await Doctor.UpdateAccountInfo(doc);
            return RedirectToAction("GetAllDoctor", "Doctor");
        }

        //public IActionResult Delete(int id)
        //{
        //    var DocData = Doctor.GetAll();
        //    ViewBag.DoctorList = Doctor.GetAll();
        //    return View();
        //}
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
               var data= await  Doctor.Delete(id);
                return Json(data);
        }


        public IActionResult GetAllDoctor(int id)
        {
            var DocData = Doctor.GetAll();

            ViewBag.DoctorNumber= DocData.Count();
            ViewBag.DoctorList = Doctor.GetAll();

            return View();
        }

        public async Task< IActionResult> ViewDoctor(int id)
        {
            var getDoc =await Doctor.GetByID(id);
            return View(getDoc);
        }
        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> SSNUssed(string ssn)
        {
            var Ssn = Doctor.SSNUnUsed(ssn);
            if (Ssn ==false)
            {
                return Json($"SSN:  {ssn} is already in use.");
            }

            return Json(true);
        }


    }
}
