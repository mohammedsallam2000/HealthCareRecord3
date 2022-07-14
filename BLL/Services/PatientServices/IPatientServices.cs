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
        PatientViewModel GetBySSN(string SSN);
        Task<PatientViewModel> GetByID(int id);
        IEnumerable<PatientViewModel> GetAll();
        bool SSNUnUsed(string ssn);
        int PatiantId(String UserId);
        int CountOfSersvive(int id);
    }
}
