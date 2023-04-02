using DAL.Models.vacation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services._1Vacation.VacationServices.RequestVacationSevice
{
    public interface IRequestVacationSevice
    {
        bool Add(VacationPlainViewModel model,int[] DoyOfWeekCheeked);
        bool Update(RequestVacationViewModel model);
        bool Delete(int id);
       Task< RequestVacationViewModel> GetByID(int id);
        Task<string> user(string userId);

        Task<IEnumerable<RequestVacationViewModel>> GetAllAsync();
    }
}
