using DAL.Models.vacation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services._1Vacation.VacationServices.VacationTypeSevice
{
    public interface IVacationTypeSevice
    {
        bool Add(VacationTypeViewModel model);
        bool Update(VacationTypeViewModel model);
        bool Delete(int id);
        VacationTypeViewModel GetByID(int id);

        IEnumerable<VacationTypeViewModel> GetAll();
    }
}
