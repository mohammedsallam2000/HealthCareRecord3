using BLL.Services.PatientServices;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.DoctorWork
{
    public class DoctorPagesController : Controller
    {
        private readonly IPatientServices patient;

        public DoctorPagesController(IPatientServices patient)
        {
            this.patient = patient;
        }
        public IActionResult MyPatiants(int id)
        {
            var data = patient.GetByID(id);
            return View(data);
        }
        public IActionResult DoctorWork(int id)
        {

            return View();
        }
    }
}
