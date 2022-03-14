using DAL.Database;
using DAL.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Helper;

namespace BLL.Services.NerseServices
{
    public class NurseServices : INurseServices
    {
        private readonly AplicationDbContext db;
        private UserManager<IdentityUser> userManager;
        public NurseServices(AplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            this.db = db;
        }

        public async Task<int> Add(NurseViewModel Nurse)
        {
            Nurse obj = new Nurse();
            obj.Name = Nurse.Name;
            obj.SSN = Nurse.SSN;
            obj.Phone = Nurse.Phone;
            obj.Address = Nurse.Address;
            obj.BirthDate = Nurse.BirthDate;
            obj.Gender = Nurse.Gender;
            obj.Photo = UploadFileHelper.SaveFile(Nurse.PhotoUrl, "Photos");
            var user = new IdentityUser()
            {
                Email = Nurse.Email,
                UserName = Nurse.Email,
            };
            var result = await userManager.CreateAsync(user, Nurse.Password);
            var user2 = await userManager.FindByEmailAsync(Nurse.Email);
            //var result2 = await userManager.AddToRoleAsync(user2, "Doctor");
            obj.UserId = user2.Id;
            //obj.UserId = userManager.FindByEmailAsync(emp.Email).Result.Id;
            await db.Nurses.AddAsync(obj);
                int res = await db.SaveChangesAsync();
                if (res > 0)
                {
                    return obj.Id;
                }
                return 0;

            
        }

        public bool Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    var DeletedObject = db.Nurses.Find(id);
                    UploadFileHelper.RemoveFile("Photos/", DeletedObject.Photo);
                    db.Nurses.Remove(DeletedObject);
                    db.SaveChanges();
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


        public IEnumerable<NurseViewModel> GetAll()
        {
            List<NurseViewModel> nurse = new List<NurseViewModel>();
            foreach (var item in db.Nurses)
            {
                NurseViewModel obj = new NurseViewModel();
                obj.Address = item.Address;
                obj.BirthDate = item.BirthDate;
                obj.Gender = item.Gender;
                obj.Name = item.Name;
                obj.Phone = item.Phone;
                obj.SSN = item.SSN;
                obj.WorkStartTime = item.WorkStartTime;
                obj.Photo = item.Photo;
                nurse.Add(obj);
            }
            return nurse;
        }

        public NurseViewModel GetByID(int id)
        {
            Nurse nurse = db.Nurses.FirstOrDefault(x => x.Id == id);
            NurseViewModel obj = new NurseViewModel();
            obj.Address = nurse.Address;
            obj.BirthDate = nurse.BirthDate;
            obj.Gender = nurse.Gender;
            obj.Name = nurse.Name;
            obj.Phone = nurse.Phone;
            obj.SSN = nurse.SSN;
            obj.WorkStartTime = nurse.WorkStartTime;
            obj.Photo = nurse.Photo;
            return obj;
        }

        public bool Update(NurseViewModel Nurse)
        {
            throw new NotImplementedException();
        }
    }
}
