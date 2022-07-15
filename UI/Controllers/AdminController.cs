using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
