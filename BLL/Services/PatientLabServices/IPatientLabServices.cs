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
        IEnumerable<PatientLabViewModel> GetAll();
        PatientLabViewModel GetByID(int id);
        Task<int> Create(PatientLabViewModel model);
        Task<int> Edit(PatientLabViewModel model);
    }
}
