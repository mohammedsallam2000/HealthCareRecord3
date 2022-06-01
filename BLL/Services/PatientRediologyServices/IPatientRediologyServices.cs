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
        public IEnumerable<PatientRediologyViewModel> GetAllUnActive(int id);

        IEnumerable<PatientRediologyViewModel> GettheLast(int id);
        IEnumerable<PatientRediologyViewModel> Getsession(int id);
        PatientRediologyViewModel GetRediology(int id);
        PatientRediologyViewModel GetByID(int id);
        int Create(string[] Radiology, int DailyDetectionId);
        Task<int> Edit(PatientRediologyViewModel model);
    }
}
