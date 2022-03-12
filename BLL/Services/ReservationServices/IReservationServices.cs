using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Services.ReservationServices
{
    public interface IReservationServices
    {
        bool Add(DailyDetectionViewModel detec);
        IEnumerable<ShiftViewModel> GetAll();
    }
}
