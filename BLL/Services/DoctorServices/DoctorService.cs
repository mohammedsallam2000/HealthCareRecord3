using BLL.Helper;
using DAL.Database;
using DAL.Entities;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly AplicationDbContext context;
        private UserManager<IdentityUser> userManager;
        public DoctorService(AplicationDbContext context , UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            this.context = context;
        } 


        public async Task<int> Add(DoctorViewModel doc)
        {
                Doctor obj = new Doctor();
                obj.Name = doc.Name;
                obj.SSN = doc.SSN;
                obj.Phone = doc.Phone;
                obj.Address = doc.Address;
                obj.ShiftId = doc.ShiftId;
                obj.BirthDate = doc.BirthDate;
                obj.Degree = doc.Degree;            
                obj.Gender = doc.Gender;
                obj.DepartmentId = doc.DepartmentId;
                obj.Photo = UploadFileHelper.SaveFile(doc.PhotoUrl, "Photos");
                var user = new IdentityUser()
                {
                    Email = doc.Email,
                    UserName = doc.Email,
                };
                var result = await userManager.CreateAsync(user, doc.Password);
                var user2 = await userManager.FindByEmailAsync(doc.Email);
                //var result2 = await userManager.AddToRoleAsync(user2, "Doctor");
                if (result.Succeeded /*&& result2.Succeeded*/)
                {
                    obj.UserId = user2.Id;
                    //obj.UserId =  userManager.FindByEmailAsync(emp.Email).Result.Id;
                    await context.Doctors.AddAsync(obj);
                    int res = await context.SaveChangesAsync();
                    if (res > 0)
                    {
                        return obj.Id;
                    }
                    return 0;
                }
                return 0;
        }
        public async Task<int> Update(DoctorViewModel doc)
        {
            var OldData = context.Doctors.FirstOrDefault(x => x.Id == doc.Id);
                OldData.Name = doc.Name;
                OldData.BirthDate = doc.BirthDate;
                OldData.Gender = doc.Gender;
                OldData.Name = doc.Name;
                OldData.ShiftId = doc.ShiftId;
                OldData.Phone = doc.Phone;
                //OldData.Photo = UploadFileHelper.SaveFile(doc.PhotoUrl, "Photos");
                var user = await userManager.FindByIdAsync(OldData.UserId);
                user.Email = doc.Email;
                user.UserName = doc.Email;
                var result = await userManager.UpdateAsync(user);
                await context.SaveChangesAsync();
                return 0;
           
        }




        public async Task <bool> Delete(int id)
        {
            try
            {

                var DeletedObject = context.Doctors.FirstOrDefault(x => x.Id == id);
                UploadFileHelper.RemoveFile("Photos/", DeletedObject.Photo);
                context.Doctors.Remove(DeletedObject);
                var user = await userManager.FindByIdAsync(DeletedObject.UserId);
                await userManager.DeleteAsync(user);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    
       

        public IEnumerable<DoctorViewModel> GetAll()
        {
            List<DoctorViewModel> doc = new List<DoctorViewModel>();
            foreach (var item in context.Doctors)
            {
                DoctorViewModel obj = new DoctorViewModel();
                obj.Address = item.Address;
                obj.BirthDate = item.BirthDate;
                obj.Degree = item.Degree;
                obj.Gender = item.Gender;
                obj.Name = item.Name;
                obj.Phone = item.Phone;
                obj.DepartmentName = context.Departments.Where(x => x.DepartmentId == item.DepartmentId).Select(x => x.Name).FirstOrDefault();
                obj.SSN = item.SSN;
                obj.WorkStartTime = item.WorkStartTime;
                obj.Photo = item.Photo;
                obj.Id = item.Id;
                doc.Add(obj);
            }
            return doc;
        }

        public DoctorViewModel GetByID(int id)
        {
                Doctor doc = context.Doctors.FirstOrDefault(x => x.Id ==id);
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

      
        public IEnumerable<DoctorViewModel> GetAll(int id, int ShiftId)
        {
            List<DoctorViewModel> doc = new List<DoctorViewModel>();
            foreach (var item in context.Doctors.Where(x => x.DepartmentId == id && x.ShiftId == ShiftId))
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
    }
}
