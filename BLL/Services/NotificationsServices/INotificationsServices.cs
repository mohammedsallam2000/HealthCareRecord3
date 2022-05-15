using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.NotificationsServices
{
   public interface INotificationsServices
    {
        int Create(string name);
        IEnumerable<NotificationsViewModel> GetAll()
    }
}
