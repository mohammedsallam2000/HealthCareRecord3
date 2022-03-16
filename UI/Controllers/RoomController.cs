using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult AddRoom()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult AddRoom()
        //{
        //    return View();
        //}
        public IActionResult UpdateRoom()
        {
            return View();
        }
        public IActionResult ViewAllRoom()
        {
            return View();
        }
    }
}
