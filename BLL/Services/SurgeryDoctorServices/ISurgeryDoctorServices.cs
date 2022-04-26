using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.SurgeryDoctorServices
{
   public interface ISurgeryDoctorServices
    {
        IEnumerable<SurgeryDoctorViewModel> GetAllOrders();
        PatientSurgeryViewModel ConfirmOrder(int id);

        public bool Cancel(int Id);
    }
}
