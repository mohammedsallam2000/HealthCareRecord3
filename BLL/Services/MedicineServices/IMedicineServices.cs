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

        decimal GetPrie(string name);

        IEnumerable<MedicineViewModel> GetAll();
        //IEnumerable<TreatmentViewModel> GetAllTreatment(int id);
        IEnumerable<MedicineViewModel> GetAllEnd();


        MedicineViewModel GetByID(int id);
    }
}
