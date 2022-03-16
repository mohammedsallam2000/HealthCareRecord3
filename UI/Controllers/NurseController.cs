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
            return RedirectToAction("Create", "Booking");
        }


        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(NurseViewModel nurse)
        {
            Nurse.Update(nurse);
            return RedirectToAction("Create", "Booking");
        }



        public IActionResult Delete(int id)
        {
            var Data = Nurse.GetByID(id);
            return View();
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            Nurse.Delete(id);
            return RedirectToAction("Index", "Doctor");
        }
    }
}
