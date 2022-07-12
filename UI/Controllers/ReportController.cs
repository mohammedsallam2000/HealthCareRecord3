using BLL.Services.PatientServices;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace UI.Controllers
{
    public class ReportController : Controller
    {
        private readonly IPatientServices patient;

        public ReportController(IPatientServices patient)
        {
            this.patient = patient;
        }
        public IActionResult PatiantProfile(int id)
        {
            var data=patient.GetByID(id);
            return new ViewAsPdf(data);
        }
    }
}
