using BLL.Services.RoomServices;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomServices room;

        public RoomController( IRoomServices room)
        {
            this.room = room;
        }
        public IActionResult AddRoom()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRoom(RoomVM rooms)
        {
            var data = room.Add(rooms);
            return View();
        }
        public IActionResult UpdateRoom(int id)
        {

            var data = room.GetByID(id); 

            return View(data);
        }
        [HttpPost]
        public IActionResult UpdateRoom(RoomVM rooms)
        {

            var data = room.Update(rooms);

            return RedirectToAction("ViewAllRoom");
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
        [HttpPost]
        public IActionResult Delete(int id)
        {

            var data = room.Delete(id);

            return RedirectToAction("ViewAllRoom");
        }
    }
}
