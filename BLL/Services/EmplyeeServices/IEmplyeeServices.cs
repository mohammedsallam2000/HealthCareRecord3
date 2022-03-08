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
        IQueryable<EmplyeeViewModel> Get();
        EmplyeeViewModel GetById(int id);
        Task<bool> Add(EmplyeeViewModel EmplyeeViewModel);
        void Update(EmplyeeViewModel EmplyeeViewModel);
        void Delete(int id);
    }
}
