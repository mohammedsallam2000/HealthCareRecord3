using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.MedicineServices
{
    public interface IMedicineServices
    {
        bool Add(MedicineViewModel medicine);
        bool Update(MedicineViewModel medicine);

      

        IEnumerable<MedicineViewModel> GetAll();
        IEnumerable<MedicineViewModel> GetAllEnd();


        MedicineViewModel GetByID(int id);
    }
}
