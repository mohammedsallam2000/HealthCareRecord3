using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using BLL.Services;
using System.Threading.Tasks;
using BLL.Services.NerseServices;
using Microsoft.AspNetCore.Authorization;

namespace UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NurseController : Controller
    {
        private readonly INurseServices Nurse;
        public NurseController(INurseServices Nurse)
        {
            this.Nurse = Nurse;
        }

        public IActionResult AddNurse()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNurse(NurseViewModel nurse)
        {
            if (ModelState.IsValid)
            {
                await Nurse.Add(nurse);
                ViewBag.Success = 1;
            }
           
            return View();
        }


        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditAccountInfo(NurseViewModel nurse)
        {
            await Nurse.UpdateAccountInfo(nurse);
            return RedirectToAction("GetAllNurse");
        }
        [HttpPost]
        public async Task<IActionResult> EditBasicInfo(NurseViewModel nurse)
        {
            await Nurse.UpdateBasicInfo(nurse);
            return RedirectToAction("GetAllNurse");
        }



        //public IActionResult Delete(int id)
        //{
        //    var Data = Nurse.GetByID(id);
        //    return View();
        //}
        //[HttpPost]
        //[ActionName("Delete")]
        public async Task<JsonResult> Delete(int id)
        {
           var data= await Nurse.Delete(id);
            return Json(data);
        }

        public IActionResult GetAllNurse(int id)
        {
            var DocData = Nurse.GetAll();
            ViewBag.DoctorList = Nurse.GetAll();
            return View();
        }

        public IActionResult ViewNurse(int id)
        {
            var getDoc = Nurse.GetByID(id);
            return View(getDoc);
        }
        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> SSNUssed(string ssn)
        {
            var Ssn = Nurse.SSNUnUsed(ssn);
            if (Ssn == false)
            {
                return Json($"SSN:  {ssn} is already in use.");
            }

            return Json(true);
        }
    }
}
