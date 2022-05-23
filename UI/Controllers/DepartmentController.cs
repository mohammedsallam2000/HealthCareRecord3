using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services.DepartmentServices;
using DAL.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;

namespace UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentSevice dps;

        public DepartmentController(IDepartmentSevice dps)
        {
            this.dps = dps;
        }
        public IActionResult Index()
        {
            var depts = dps.GetAll();
            return View(depts);
        }

        public IActionResult Create()
        {
             
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentViewModel dpt)
        {
            try
            {
                dps.Add(dpt);
                return RedirectToAction("GetAllDepartments");
            }
            catch (Exception)
            {

                return View(dpt);
            }
        }

        public IActionResult GetAllDepartments(DepartmentViewModel dpt)
        {

            return View();
        }

        public IActionResult Edit(int id)
        {
            var data = dps.GetByID(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentViewModel dpt)
        {
            try
            {
                dps.Update(dpt);
                return RedirectToAction("GetAllDepartments", "Department");
            }
            catch (Exception)
            {

                return View(dpt);
            }
        }

        public IActionResult Delete(int id)
        {
             dps.Delete(id);
            return RedirectToAction("GetAllDepartments", "Department");
        }
    }
}
