using DAL.Database;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.NerseServices
{
    public class NurseServices : INurseServices
    {
        private readonly AplicationDbContext db = new AplicationDbContext();

        public bool Add(NurseViewModel Nurse)
        {
            db.Add(Nurse);
            db.SaveChanges();
            return true;
        }

        public bool Delete(NurseViewModel Nurse)
        {
            throw new NotImplementedException();
        }

        public IQueryable<NurseViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<NurseViewModel> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(NurseViewModel Nurse)
        {
            throw new NotImplementedException();
        }
    }
}
