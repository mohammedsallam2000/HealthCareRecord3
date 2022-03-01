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
            var data = Doctor.GetAll();
            ViewBag.DoctorList = new SelectList(data);
            return View();
        }
        [HttpPost]
        public IActionResult Create(DoctorViewModel doc)
        {
            try
            {
             
                    Doctor.Add(doc);
                    //return RedirectToAction("Index", "Doctor");
                
                return View(doc);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(doc);
            }


        }




        public IActionResult Edit(int id)
        {
            var data = Doctor.GetByID(id);
            ViewBag.DoctorList = Doctor.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Edit(DoctorViewModel doc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Doctor.Update(doc);
                    return RedirectToAction("Index", "Doctor");
                }

                var data = Doctor.GetAll();

                ViewBag.DepartmentList = new SelectList(data);
                return View(doc);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(doc);
            }


        }




        public IActionResult Delete(int id)
        {
            var Data = Doctor.GetByID(id);
            var DocData = Doctor.GetAll();
            ViewBag.DoctorList = Doctor.GetAll();
            return View();
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                Doctor.Delete(id);
                return RedirectToAction("Index", "Doctor");
            }
            catch (Exception ex)
            {

                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View();
            }

        }

        public IActionResult Ahmed() {
            return View();
        }

    }
}
