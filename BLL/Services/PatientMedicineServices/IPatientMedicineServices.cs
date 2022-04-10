using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using System.Threading.Tasks;

namespace BLL.Services.PatientMedicineServices
{
    public interface IPatientMedicineServices
    {
        IEnumerable<PatientMedicineViewModel> GetAll(int id);
        bool Add(string[] Medicine,string Document, int DailyDetectionId);
    }
}
