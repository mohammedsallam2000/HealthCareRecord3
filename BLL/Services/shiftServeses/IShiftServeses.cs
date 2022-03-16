using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.shiftServeses
{
    public interface IShiftServeses
    {
       void Add(ShiftViewModel Nurse);
        bool Update(ShiftViewModel Nurse);

        IEnumerable<ShiftViewModel> GetAll();
        ShiftViewModel GetByID(int id);
    }
}
