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
        IEnumerable<PatientRediologyViewModel> GetAll(int id);
        PatientRediologyViewModel GetByID(int id);
        int Create(string[] Radiology, int patiastId, int DoctorId);
        Task<int> Edit(PatientRediologyViewModel model);
    }
}
