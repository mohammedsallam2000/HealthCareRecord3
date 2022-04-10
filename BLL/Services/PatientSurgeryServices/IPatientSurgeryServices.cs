using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.PatientSurgeryServices
{
    public interface IPatientSurgeryServices
    {
        IEnumerable<PatientSurgeryViewModel> GetAll(int id);
        PatientSurgeryViewModel GetByID(int id);
        Task<int> Create(PatientSurgeryViewModel model);
        Task<int> Edit(PatientSurgeryViewModel model);
    }
}
