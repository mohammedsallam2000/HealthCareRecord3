using BLL.Services.PatientServices;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class ReportController : Controller
    {
        private readonly IPatientServices patient;

        public ReportController(IPatientServices patient)
        {
            this.patient = patient;
        }
        public async Task<IActionResult> PatiantProfile(int id)
        {
            var data= await patient.GetByID(id);
            
            return new ViewAsPdf(data);
        }
    }
}
