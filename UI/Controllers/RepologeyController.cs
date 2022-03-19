using BLL.Services.RepologeyServices;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class RepologeyController : Controller
    {
        private readonly IRepologeyServices repologey;

        public RepologeyController(IRepologeyServices repologey)
        {
            this.repologey = repologey;
        }
        public IActionResult AddRepologey()
        {
            ViewBag.Rap = "";
            return View();
        }
        [HttpPost]
        public IActionResult AddRepologey(RadiologyViewModel Rad)
        {
            var data = repologey.Add(Rad);
            if (data == true)
            {
                ViewBag.Rap = "true";
                return View();

            }
            else
            {
                ViewBag.Rap = "1";
                return View(Rad);

            }
        }
        public IActionResult UpdateRepologey(int id)
        {

            var data = repologey.GetByID(id);
            ViewBag.Rap = "";
            return View(data);
        }
        [HttpPost]
        public IActionResult UpdateRepologey(RadiologyViewModel rad)
        {

            var data = repologey.Update(rad);
            if (data == true)
            {
                return RedirectToAction("ViewAllRepologey");

            }
            else
            {
                ViewBag.Rap = "Please Change the Repologey Name  it Used befoer";
                return View(rad);
            }

        }
        public IActionResult ViewAllRepologey()
        {
            var data = repologey.GetAll();
            return View(data);

        }
        public IActionResult GetAllDeletedRepologey()
        {
            var data = repologey.GetAllDeletd();
            return View(data);

        }
        //[HttpPost]
        // Delete Action=ViewAllRoom(int id)
        public JsonResult Delete(int id)
        {

            var data = repologey.Delete(id);
            //if (data == true)
            //{
            //    ViewBag.Room = "Delete";


            //}
            //else
            //{
            //    ViewBag.Room = "";
            //}
            return Json(data);

        }
        public JsonResult UpdateDelete(int id)
        {

            var data = repologey.UpdateDelete(id);
            //if (data == true)
            //{
            //    ViewBag.Room = "Delete";


            //}
            //else
            //{
            //    ViewBag.Room = "";
            //}
            return Json(data);

        }
    }
}
