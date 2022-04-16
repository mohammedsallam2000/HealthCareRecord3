using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.PatientLabServices
{
    public interface IPatientLabServices
    {
        IEnumerable<PatientLabViewModel> GetAll(int id);
        IEnumerable<PatientLabViewModel> GetTheLast(int id);

        PatientLabViewModel GetByID(int id);
        int Create(string []Lab,int DealyDetctionId);
        Task<int> Edit(PatientLabViewModel model);
    }
}
