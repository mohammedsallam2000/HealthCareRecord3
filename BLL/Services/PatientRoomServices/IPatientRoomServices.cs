using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.PatientRoomServices
{
    public interface IPatientRoomServices
    {
        IEnumerable<PatientRoomViewModel> GetAll(int id);
        PatientRoomViewModel GetByID(int id);
        Task<int> Create(PatientRoomViewModel model);
        Task<int> Edit(PatientRoomViewModel model);
    }
}
