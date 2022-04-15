using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.LabDoctorWorkServices
{
    public interface ILabDoctorWorkServices
    {
        IEnumerable<LabDoctorWorkViewModel> GetAllOrders();
        LabDoctorWorkViewModel GetByID(int id);
        Task<int> AddResult(LabDoctorWorkViewModel model);
    }
}
