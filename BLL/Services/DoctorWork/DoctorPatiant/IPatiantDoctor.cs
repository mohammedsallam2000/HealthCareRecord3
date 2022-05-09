using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.DoctorWork.DoctorPatiant
{
    public interface IPatiantDoctor
    {
        IEnumerable<DailyDetectionViewModel> GetAll(string id);
        Task<DoctorWorkVM> GetByID(int id);
        DoctorWorkVM GetPatientByID(int id);
        int FinshPataiant(int id);
       


    }
}
