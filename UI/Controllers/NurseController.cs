using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class NurseController : Controller
    {
        public IActionResult AddNurse()
        {
            return View();
        }
    }
}
