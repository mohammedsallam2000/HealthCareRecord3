using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.DoctorWork
{
    public class DoctorPagesController : Controller
    {
        public IActionResult MyPatiants()
        {
            return View();
        }
    }
}
