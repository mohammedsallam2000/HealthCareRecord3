using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.DepartmentServices
{
    public interface IDepartmentSevice
    {
        bool Add(DepartmentViewModel dept);
        bool Update(DepartmentViewModel dept);
        bool Delete(int id);
        DepartmentViewModel GetByID(int id);
        IEnumerable<DepartmentViewModel> GetAll();
    }
}
