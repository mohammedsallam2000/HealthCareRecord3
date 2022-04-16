using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.PharmacistWorkServices
{
    public interface IPharmacistWorkServices
    {
        PharmacistWorkViewModel GetByID(int id);
        IEnumerable<PharmacistWorkViewModel> GetAllOrders();
    }
}
