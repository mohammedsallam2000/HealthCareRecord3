using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.RadiologyDoctorWorkServices
{
    public interface IRadiologyDoctorWorkServices
    {
        RadiologyDoctorWorkViewModel GetByID(int id);
        IEnumerable<RadiologyDoctorWorkViewModel> GetAllOrders();

        Task<int> AddResult(RadiologyDoctorWorkViewModel model);
        IEnumerable<RadiologyDoctorWorkViewModel> GetAllCompletedOrders();
    }
}
