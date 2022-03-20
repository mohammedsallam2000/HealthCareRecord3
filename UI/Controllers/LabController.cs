using BLL.Services.LabServices;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class LabController : Controller
    {
        private readonly ILabServices lab;

        public LabController(ILabServices lab)
        {
            this.lab = lab;
        }
        public IActionResult AddLab()
        {
            ViewBag.lab = "";
            return View();
        }
        [HttpPost]
        public IActionResult AddLab(LabViewModel Lab)
        {
            var data = lab.Add(Lab);
            if (data == true)
            {
                ViewBag.lab = "true";
                return View();

            }
            else
            {
                ViewBag.lab = "1";
                return View(Lab);

            }
        }
        public IActionResult UpdateLab(int id)
        {

            var data = lab.GetByID(id);
            ViewBag.lab = "";
            return View(data);
        }
        [HttpPost]
        public IActionResult UpdateLab(LabViewModel Lab)
        {

            var data = lab.Update(Lab);
            if (data == true)
            {
                return RedirectToAction("ViewAllLab");

            }
            else
            {
                ViewBag.lab = "1";
                return View(Lab);
            }

        }
        public IActionResult ViewAllLab()
        {
            var data = lab.GetAll();
            return View(data);

        }
        public IActionResult GetAllDeletedLab()
        {
            var data = lab.GetAllDeletd();
            return View(data);

        }
       
        public JsonResult Delete(int id)
        {

            var data = lab.Delete(id);
           
            return Json(data);

        }
        public JsonResult UpdateDelete(int id)
        {

            var data = lab.UpdateDelete(id);
           
            return Json(data);

        }
    }
}
