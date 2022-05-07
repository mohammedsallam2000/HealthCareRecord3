using BLL.Services.RoomServices;
using BLL.Services.RoomWorkServices;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoomController : Controller
    {
        private readonly IRoomServices room;
        private readonly IRoomWorkServices roomWork;

        public RoomController( IRoomServices room , IRoomWorkServices roomWork)
        {
            this.room = room;
            this.roomWork = roomWork;
        }
        public IActionResult AddRoom()
        {
            ViewBag.Room = "";
            return View();
        }
        [HttpPost]
        public IActionResult AddRoom(RoomVM rooms)
        {
            var data = room.Add(rooms);
            if (data==true)
            {
                ViewBag.Room = "true";
                return View();

            }
            else
            {
                ViewBag.Room = "1";
                return View(rooms);

            }
        }
        public IActionResult UpdateRoom(int id)
        {

            var data = room.GetByID(id);
            ViewBag.Room = "";
            return View(data);
        }
        [HttpPost]
        public IActionResult UpdateRoom(RoomVM rooms)
        {

            var data = room.Update(rooms);
            if (data==true)
            {
                return RedirectToAction("ViewAllRoom");

            }
            else
            {
                ViewBag.Room = "Please Change the Room Number it Used befoer";
                return View(rooms);
            }

        }
        public IActionResult ViewAllRoom()
        {
            var data = room.GetAll();
            return View(data);
           
        }
        public IActionResult GetAllUnUsedRoom()
        {
            var data = room.GetAllUnUsedRoom();
            return View(data);

        }
        //[HttpPost]
        // Delete Action=ViewAllRoom(int id)
        public JsonResult Delete(int id)
        {

            var data = room.Delete(id);
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

            var data = room.UpdateDelete(id);
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


        public IActionResult WaitingPage()
        {
            return View();
        }

        public IActionResult ConfirmOrder(int id)
        {
            roomWork.ConfirmOrder(id);
            return RedirectToAction("WaitingPage");
        }

        public JsonResult Cancel(int Id)
        {

            var data = roomWork.Cancel(Id);
            return Json(data);

        }
    }
}
