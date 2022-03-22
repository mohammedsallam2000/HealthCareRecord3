using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.PatientServices
{
    public interface IPatientServices
    {
        Task<int> Add(PatientViewModel patient);
        Task<int> Edit(PatientViewModel patient);
       bool Delete(int id);
        Task<PatientViewModel> GetByID(int id);
        IEnumerable<PatientViewModel> GetAll();
    }
}
