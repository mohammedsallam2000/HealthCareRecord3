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


namespace UI.Controllers
{
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

                await Doctor.Add(doc);
                return RedirectToAction("Create", "Booking");

        }

        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DoctorViewModel doc)
        {
            await Doctor.Update(doc);
             return RedirectToAction("Create", "Booking");        
        }


        //public IActionResult Delete(int id)
        //{
        //    var DocData = Doctor.GetAll();
        //    ViewBag.DoctorList = Doctor.GetAll();
        //    return View();
        //}
        //[HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
               await  Doctor.Delete(id);
                return RedirectToAction("GetAllDoctor", "Nurse");
        }


        public IActionResult GetAllDoctor(int id)
        {
            var DocData = Doctor.GetAll();
            ViewBag.DoctorList = Doctor.GetAll();
            return View();
        }

        public IActionResult ViewDoctor(int id)
        {
            var getDoc = Doctor.GetByID(id);
            return View(getDoc);
        }


    }
}
