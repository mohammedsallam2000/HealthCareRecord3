using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using BLL.Services;
using System.Threading.Tasks;
using BLL.Services.NerseServices;
namespace UI.Controllers
{
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
           await Nurse.Add(nurse);
            return RedirectToAction("GetAllNurse");
        }


        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(NurseViewModel nurse)
        {
            await Nurse.Update(nurse);
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
