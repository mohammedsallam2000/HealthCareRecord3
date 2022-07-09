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
        Task<int> Add(DoctorViewModel doc);
        Task<int> UpdateBasicInfo(DoctorViewModel doc);
        Task<int> UpdateAccountInfo(DoctorViewModel doc);
        Task<bool> Delete(int id);
          Task<DoctorViewModel> GetByID(int id);
            IEnumerable<DoctorViewModel> GetAll(int id , int ShiftId);
            IEnumerable<DoctorViewModel> GetAll();
        bool SSNUnUsed(string ssn);
    }
}
