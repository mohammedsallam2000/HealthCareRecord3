using BLL.Services.EmplyeeServices;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Authorize(Roles = "Admin")]
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
            var check = await emplyee.Add(model);
            if (check == 1)
            {
                ViewBag.Success = 1;
            }
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

        #region Emplyee Profile
        public async Task<IActionResult> Profile(int id)
        {
            var getEmplyee = await emplyee.GetByID(id);
            return View(getEmplyee);
        }
        #endregion

        #region Edit Emplyee
        [HttpPost]
        public async Task<IActionResult> Edit(EmplyeeViewModel model)
        {
            await emplyee.Edit(model);
            return RedirectToAction("GetAll", "Emplyee");
        }
        #endregion
        #region Delete Emplyee
        [HttpPost]
        public JsonResult Delete(int id)
        {

            var data = emplyee.Delete(id);

            return Json(data);

        }
        #endregion

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> SSNUssed(string ssn)
        {
            var Ssn = emplyee.SSNUnUsed(ssn);
            if (Ssn == false)
            {
                return Json($"SSN:  {ssn} is already in use.");
            }

            return Json(true);
        }
    }
}
