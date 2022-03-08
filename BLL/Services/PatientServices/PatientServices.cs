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

namespace BLL.Services.PatientServices
{
    public class PatientServices : IPatientServices
    {
        private UserManager<IdentityUser> userManager;
        private readonly AplicationDbContext db;
        public PatientServices(UserManager<IdentityUser> userManager, AplicationDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }

        public async Task<bool> Add(PatientViewModel patient)
        {
            Patient obj = new Patient();
            obj.Name = patient.Name;
            obj.SSN = patient.SSN;
            obj.BirthDate = patient.BirthDate;
            obj.Gender = patient.Gender;
            obj.Phone = patient.Phone;
            obj.AnotherPhone = patient.AnotherPhone;
            obj.Address = patient.Address;
            obj.AnotherPhone = patient.AnotherPhone;
          //  obj.Phone = UploadFileHelper.SaveFile(patient.PhotoUrl, "Photos");
            obj.LogInTime = DateTime.Now;

            var user = new IdentityUser()
            {
                Email = patient.Email,
                UserName = patient.Email,
            };
            var result = await userManager.CreateAsync(user, patient.Password);
            var user2 = await userManager.FindByEmailAsync(patient.Email);
            var result2 = await userManager.AddToRoleAsync(user2, "Patient");
            if (result.Succeeded && result2.Succeeded)
            {
                //
                obj.UserId = user2.Id;
                //obj.UserId =  userManager.FindByEmailAsync(emp.Email).Result.Id;
                await db.Patients.AddAsync(obj);
                int res = await db.SaveChangesAsync();
                if (res > 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PatientViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PatientViewModel GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(PatientViewModel patient)
        {
            throw new NotImplementedException();
        }
    }
}
