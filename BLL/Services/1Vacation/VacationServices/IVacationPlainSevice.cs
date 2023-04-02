using DAL.Models;
using DAL.Models.vacation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services._1Vacation.VacationServices
{
    public interface IVacationServices
    {
        bool Add(VacationPlainViewModel model);
        bool Update(VacationPlainViewModel model);
        bool Cancel(int id);
        VacationPlainViewModel GetByID(int id);
        
        IEnumerable<VacationPlainViewModel> GetAll();
    }
}
