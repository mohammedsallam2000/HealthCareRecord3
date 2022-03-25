using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.LabServices
{
    public interface ILabServices
    {
        bool Add(LabViewModel lab);
        bool Update(LabViewModel lab);

        bool Delete(int id);
        bool UpdateDelete(int id);

        IEnumerable<LabViewModel> GetAll();
        IEnumerable<LabViewModel> GetAllDeletd();


        LabViewModel GetByID(int id);
    }
}
