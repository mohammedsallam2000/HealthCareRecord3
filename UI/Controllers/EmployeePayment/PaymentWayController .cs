using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services.DepartmentServices;
using DAL.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using BLL.Services.EmployeePayment.TypeWork;
using DAL.Models.UserWork;
using BLL.Services.EmployeePayment.PaymentWay;

namespace UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PaymentWayController : Controller
    {
        private readonly IPaymentWayService dps;

        public PaymentWayController(IPaymentWayService dps)
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
        public IActionResult Create(PaymentViewModel dpt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dps.Add(dpt);
                    ViewBag.Success = 1;
                }
                
                return View();
            }
            catch (Exception)
            {

                return View(dpt);
            }
        }

        public IActionResult GetAllPaymentWay(PaymentViewModel dpt)
        {

            return View();
        }

        public IActionResult Edit(int id)
        {
            var data = dps.GetByID(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(PaymentViewModel dpt,int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dpt.Id = Id;
                    ViewBag.Success = 1;
                    dps.Update(dpt);
                }
                return View(dpt);
               // return RedirectToAction("GetAllDepartments", "Department");
            }
            catch (Exception)
            {

                return View(dpt);
            }
        }

        public IActionResult Cancel(int id)
        {
             dps.Cancel(id);
            return RedirectToAction("PaymentWay", "TypeWork");
        }
    }
}
