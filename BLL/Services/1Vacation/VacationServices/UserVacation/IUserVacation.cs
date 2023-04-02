using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.vacation;

namespace BLL.Services._1Vacation.VacationServices.UserVacation
{
    public interface IUserVacation
    {


         Task <UserVacationSum> GetAll(UserVacationSum model,List<string>name);
    }
}
