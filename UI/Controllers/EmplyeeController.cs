﻿using BLL.Services.EmplyeeServices;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
   
    public class EmplyeeController : Controller
    {
        private readonly IEmplyeeServices emplyee;

        public EmplyeeController(IEmplyeeServices emplyee)
        {
            this.emplyee = emplyee;
        }

        #region Create New Emplyee
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmplyeeViewModel model)
        {
            await emplyee.Add(model);
            return RedirectToAction("GetAll", "Emplyee");
        }
        #endregion

        #region Get All Emplyees
        public IActionResult GetAll(int id)
        {
            var AllEmplyees = emplyee.GetAll();
            //ViewBag.EmpList = emp.GetAll();
            return View(AllEmplyees);
        }
        #endregion

        public async Task<IActionResult> Profile(int id)
        {
            var getEmplyee = await emplyee.GetByID(id);
            return View(getEmplyee);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmplyeeViewModel model)
        {
            await emplyee.Edit(model);
            return RedirectToAction("GetAll", "Emplyee");
        }

    }
}
