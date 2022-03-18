using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.RoomServices
{
    public interface IRoomServices
    {
       bool Add(RoomVM Nurse);
        bool Update(RoomVM Nurse);

        bool Delete(int id);
        IEnumerable<RoomVM> GetAll();
        IEnumerable<RoomVM> GetAllUnUsedRoom();

        
        RoomVM GetByID(int id);
    }
}
