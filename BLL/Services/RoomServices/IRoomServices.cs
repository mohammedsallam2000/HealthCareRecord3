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
       bool Add(RoomVM Room);
        bool Update(RoomVM Room);

        bool Delete(int id);
        bool UpdateDelete(int id);

        IEnumerable<RoomVM> GetAll();
        IEnumerable<RoomVM> GetAllUnUsedRoom();

        
        RoomVM GetByID(int id);
    }
}
