using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Models.UserWork;

namespace BLL.Services.EmployeePayment.PaymentWay
{
    public interface IPaymentWayService
    {
        bool Add(PaymentViewModel dept);
        bool Update(PaymentViewModel dept);
        bool Cancel(int id);
        PaymentViewModel GetByID(int id);

        IEnumerable<PaymentViewModel> GetAll();
    }
}
