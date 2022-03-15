using BLL.Services.shiftServeses;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class ShiftController : Controller
    {
        private readonly IShiftServeses shift;

        public ShiftController(IShiftServeses shift)
        {
            this.shift = shift;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ShiftViewModel shifts)
        {
             shift.Add(shifts);
            return View();
        }
        public IActionResult Update(int id)
        {

            var data = shift.GetByID(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Update(ShiftViewModel shifts)
        {
            shift.Update(shifts);
            return RedirectToAction("GetAll");
        }
        public IActionResult GetAll()
        {
            var data=shift.GetAll();
            return View(data);
        }
       
    }
}
