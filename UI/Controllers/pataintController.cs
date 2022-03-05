using BLL.Services.PatiantServices;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class pataintController : Controller
    {
        private readonly IPatiantService patiant;

        public pataintController(IPatiantService patiant)
        {
            this.patiant = patiant;
        }
        public IActionResult AddPatient()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPatient(PatiantVM pat)
        {
            patiant.Add(pat);
            return View();
        }
    }
}
