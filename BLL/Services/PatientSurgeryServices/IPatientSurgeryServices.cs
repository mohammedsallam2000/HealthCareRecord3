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
        IEnumerable<SurgeryViewModel> GetAll();
        public IEnumerable<PatientSurgeryViewModel> GetAllUnActive(int id);

        IEnumerable<PatientSurgeryViewModel> GetAll(int id);
        PatientSurgeryViewModel GetByID(int id);
        int Create(string surgeryName,int id);
        Task<int> Edit(PatientSurgeryViewModel model);
    }
}
