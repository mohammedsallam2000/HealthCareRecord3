using BLL.Services.MedicineServices;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MedicineController : Controller
    {
        private readonly IMedicineServices medicine;

        public MedicineController(IMedicineServices medicine)
        {
            this.medicine = medicine;
        }
        public IActionResult AddMedicine()
        {
            ViewBag.Medicine = "";
            return View();
        }
        [HttpPost]
        public IActionResult AddMedicine(MedicineViewModel Rad)
        {
            var data = medicine.Add(Rad);
            if (data == true)
            {
                ViewBag.Medicine = "true";
                return View();

            }
            else
            {
                ViewBag.Medicine = "1";
                return View(Rad);

            }
        }
        public IActionResult UpdateMedicine(int id)
        {

            var data = medicine.GetByID(id);
            ViewBag.Medicine = "";
            return View(data);
        }
        [HttpPost]
        public IActionResult UpdateMedicine(MedicineViewModel med)
        {

            var data = medicine.Update(med);
            if (data == true)
            {
                return RedirectToAction("ViewAllMedicine");

            }
            else
            {
                ViewBag.Medicine = "1";
                return View(med);
            }

        }
        public IActionResult ViewAllMedicine()
        {
            var data = medicine.GetAll();
            return View(data);

        }
        public IActionResult ViewEndMedicine()
        {
            var data = medicine.GetAllEnd();
            return View(data);

        }
       
       
    }
}
