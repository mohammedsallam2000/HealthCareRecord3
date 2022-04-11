using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.SurgeryServices
{
    public interface ISurgeryServices
    {
        Task<int> Create(SurgeryViewModel model);
        Task<int> Edit(SurgeryViewModel model);
        bool Delete(int id);
        bool UpdateDelete(int id);
        IEnumerable<SurgeryViewModel> GetAll();
        IEnumerable<SurgeryViewModel> GetAllDeleted();
        decimal GetPrice(string name);
        SurgeryViewModel GetByID(int id);
    }
}
