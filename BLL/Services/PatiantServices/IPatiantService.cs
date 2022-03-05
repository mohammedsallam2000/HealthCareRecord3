using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.PatiantServices
{
    public interface IPatiantService
    {
        IQueryable<PatiantVM> Get();
        PatiantVM GetById(int id);
        void Add(PatiantVM PatiantVM);
        void Update(PatiantVM PatiantVM);
        void Delete(int id);
    }
}
