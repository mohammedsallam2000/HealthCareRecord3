using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.PatientRediologyServices
{
    public interface IPatientRediologyServices
    {
        IEnumerable<PatientRediologyViewModel> GetAll();
        PatientRediologyViewModel GetByID(int id);
        Task<int> Create(PatientRediologyViewModel model);
        Task<int> Edit(PatientRediologyViewModel model);
    }
}
