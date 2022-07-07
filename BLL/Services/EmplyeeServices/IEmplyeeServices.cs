using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.EmplyeeServices
{
    public  interface IEmplyeeServices
    {
        IEnumerable<EmplyeeViewModel> GetAll();
        Task<EmplyeeViewModel> GetByID(int id);
        Task<int> Add(EmplyeeViewModel EmplyeeViewModel);
        Task<int> EditAccountInfo(EmplyeeViewModel emp);
        Task<int> EditBasicInfo(EmplyeeViewModel emp);
        bool Delete(int id);
        bool SSNUnUsed(string ssn);

    }
}
