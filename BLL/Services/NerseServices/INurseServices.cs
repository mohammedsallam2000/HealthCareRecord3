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
        bool Add(NurseViewModel Nurse);
        bool Update(NurseViewModel Nurse);

        bool Delete(NurseViewModel Nurse);
        IQueryable<NurseViewModel> GetAll();
        IQueryable<NurseViewModel> GetByID(int id);


    }
}
