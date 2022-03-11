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
        bool Update(PatientViewModel patient);
        bool Delete(int id);
        PatientViewModel GetByID(int id);
        IQueryable<PatientViewModel> GetAll();
    }
}
