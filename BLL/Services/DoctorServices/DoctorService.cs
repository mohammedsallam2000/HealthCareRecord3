using DAL.Database;
using DAL.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DoctorService : IDoctorService
    {
        AplicationDbContext context = new AplicationDbContext();
        public bool Add(DoctorViewModel doc)
        {
            try
            {
                Doctor obj = new Doctor();
                obj.Name = doc.Name;
                obj.SSN = doc.SSN;
                obj.Phone = doc.Phone;
                obj.Address = doc.Address;
                obj.BirthDate = doc.BirthDate;
                obj.Degree = doc.Degree;
                obj.Photo = doc.Photo;
                
                context.Doctors.Add(obj);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DoctorViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public DoctorViewModel GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(DoctorViewModel doc)
        {
            throw new NotImplementedException();
        }
    }
}
