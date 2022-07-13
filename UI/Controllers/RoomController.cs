using BLL.Services.NotificationsServices;
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
        private readonly INotificationsServices notification;

        public RoomController( IRoomServices room , IRoomWorkServices roomWork, INotificationsServices Notification)
        {
            this.room = room;
            this.roomWork = roomWork;
            notification = Notification;
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
            notification.Cancel("There are a Room order");
            
            return View();
        }

        public IActionResult ConfirmOrder(int id)
        {
            roomWork.ConfirmOrder(id);
            ViewBag.Success = 1;
            //return RedirectToAction("WaitingPage", "Room", new {ViewBag.Success });
            return RedirectToAction("WaitingPage");
        }

        public JsonResult Cancel(int Id)
        {

            var data = roomWork.Cancel(Id);
            return Json(data);

        }
    }
}
