using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Services.NerseServices
{
    public interface INurseServices
    {
        Task<int> Add(NurseViewModel Nurse);
        bool Update(NurseViewModel Nurse);

        bool Delete(int id);
        IEnumerable<NurseViewModel> GetAll();
        NurseViewModel GetByID(int id);


    }
}
