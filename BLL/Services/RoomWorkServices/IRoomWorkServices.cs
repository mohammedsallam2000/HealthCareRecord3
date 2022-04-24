using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Services.RoomWorkServices
{
   public interface IRoomWorkServices
    {
        IEnumerable<RoomWorkViewModel> GetAllOrders();
    }
}
