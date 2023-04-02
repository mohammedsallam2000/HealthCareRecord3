using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Models.UserWork;

namespace BLL.Services.EmployeePayment.TypeWork
{
    public interface ITypeWorkService
    {
        bool Add(TypeWorkViewModel dept);
        bool Update(TypeWorkViewModel dept);
        bool Cancel(int id);
        TypeWorkViewModel GetByID(int id);

        IEnumerable<TypeWorkViewModel> GetAll();
        IEnumerable<TypeWorkViewModel> GetAllDepartmentForBooking();
    }
}
