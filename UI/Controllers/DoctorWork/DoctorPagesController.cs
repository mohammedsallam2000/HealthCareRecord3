using BLL.Services.PatientServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UI.Controllers.DoctorWork
{
    [Authorize]
    public class DoctorPagesController : Controller
    {
        private readonly IPatientServices patient;

        public DoctorPagesController(IPatientServices patient)
        {
            var userId=User.FindFirstValue(ClaimTypes.NameIdentifier);
            this.patient = patient;
        }
        public IActionResult MyPatiants()
        {
            return View();
        }
        public async Task<IActionResult> DoctorWork(int id)
        {
            var data = await patient.GetByID(id);

            return View(data);
        }
    }
}
