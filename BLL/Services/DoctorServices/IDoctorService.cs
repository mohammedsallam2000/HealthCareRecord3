using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BLL.Services
{
  public  interface IDoctorService
    {
            bool Add(DoctorViewModel doc);
            bool Update(DoctorViewModel doc);
            bool Delete(int id);
            DoctorViewModel GetByID(int id);
            IEnumerable<DoctorViewModel> GetAll(int id , int ShiftId);
            IEnumerable<DoctorViewModel> GetAll();
    }
}
