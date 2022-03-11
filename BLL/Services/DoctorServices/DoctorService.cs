using BLL.Helper;
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
        //private readonly AplicationDbContext context = new AplicationDbContext();
        private readonly AplicationDbContext context;

        public DoctorService(AplicationDbContext context)
        {
           
            this.context = context;
        }
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
                obj.Gender = doc.Gender;
                //obj.Photo = UploadFileHelper.SaveFile(doc.PhotoUrl, "Photos");
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
            try
            {
                if (id > 0)
                {
                    var DeletedObject = context.Doctors.Find(id);
                    UploadFileHelper.RemoveFile("Photos/", DeletedObject.Photo);
                    context.Doctors.Remove(DeletedObject);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
    
        public IEnumerable<DoctorViewModel> GetAll(int id)
        {
            List<DoctorViewModel> doc = new List<DoctorViewModel>();
            foreach (var item in context.Doctors.Where(x=>x.DepartmentId==id))
            {
                DoctorViewModel obj = new DoctorViewModel();
                obj.Address = item.Address;
                obj.BirthDate = item.BirthDate;
                obj.Degree = item.Degree;
                obj.Gender = item.Gender;
                obj.Name = item.Name;
                obj.Phone = item.Phone;
                obj.SSN = item.SSN;
                obj.WorkStartTime = item.WorkStartTime;
                obj.Photo = item.Photo;
                obj.Id = item.Id;
                doc.Add(obj);
            }
            return doc;
        }

        public IEnumerable<DoctorViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public DoctorViewModel GetByID(int id)
        {
                Doctor doc = context.Doctors.FirstOrDefault(x => x.Id == id);
                DoctorViewModel obj = new DoctorViewModel();
                obj.Address = doc.Address;
                obj.BirthDate = doc.BirthDate;
                obj.Degree = doc.Degree;
                obj.Gender = doc.Gender;
                obj.Name = doc.Name;
                obj.Phone = doc.Phone;
                obj.SSN = doc.SSN;
                obj.WorkStartTime = doc.WorkStartTime;
                obj.Photo = doc.Photo;
                obj.Id = doc.Id;
                return obj;
        }

        public bool Update(DoctorViewModel doc)
        {
            try
            {
                var OldData = context.Doctors.Find(doc.Id);
                OldData.Id = doc.Id;
                OldData.Address = doc.Address;
                OldData.BirthDate = doc.BirthDate;
                OldData.Degree = doc.Degree;
                OldData.Gender = doc.Gender;
                OldData.Name = doc.Name;
                OldData.Phone = doc.Phone;
                OldData.SSN = doc.SSN;
                OldData.WorkStartTime = doc.WorkStartTime;
                OldData.Photo = doc.Photo;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }
    }
}
