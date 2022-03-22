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

        #region Create New Patient
        public async Task<int> Add(PatientViewModel patient)
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
            obj.photo = UploadFileHelper.SaveFile(patient.PhotoUrl, "Photos");
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
                    return obj.Id;
                }
                return 0;
            }
            return 0;
        }
        #endregion

        #region Get All Patients
        IEnumerable<PatientViewModel> IPatientServices.GetAll()
        {
            return db.Patients.Where(x=>x.IsActive==false)
                       .Select(x => new PatientViewModel
                       {
                           Id = x.Id,
                           Name = x.Name,
                           Address = x.Address,
                           BirthDate = x.BirthDate,
                           Phone = x.Phone,
                           SSN = x.SSN,
                           photo = x.photo,
                           Gender = x.Gender
                       });
        }
        #endregion

        //public PatientViewModel GetByID(int id)
        //{
        //    Patient patient = db.Patients.FirstOrDefault(x => x.Id == id);
        //    PatientViewModel obj = new PatientViewModel();
        //    obj.Id = patient.Id;
        //    obj.Name = patient.Name;
        //    obj.SSN = patient.SSN;
        //    obj.Phone = patient.Phone;
        //    return obj;
        //}

        #region Get Patient By Id
        public async Task<PatientViewModel> GetByID(int id)
        {
            var user = await userManager.FindByIdAsync(db.Patients.Where(x => x.Id == id).Select(x => x.UserId).FirstOrDefault());
            var patient = db.Patients.Where(x => x.Id == id)
                                    .Select(x => new PatientViewModel
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        Address = x.Address,
                                        BirthDate = x.BirthDate,
                                        Phone = x.Phone,
                                        SSN = x.SSN,
                                        photo = x.photo,
                                        Gender = x.Gender,
                                        UserId = x.UserId,
                                        Email = user.Email,
                                        LogInTime = x.LogInTime,
                                        LogOutTime = x.LogOutTime,
                                        IsActive = x.IsActive
                                    })
                                    .FirstOrDefault();
            return patient;
        }
        #endregion

        #region Edit Patient
        public async Task<int> Edit(PatientViewModel patient)
        {
            var OldData = db.Patients.FirstOrDefault(x => x.Id == patient.Id);
            OldData.Name = patient.Name;
            OldData.BirthDate = patient.BirthDate;
            OldData.Gender = patient.Gender;
            OldData.Address = patient.Address;
            OldData.Phone = patient.Phone;
            //OldData.Photo = UploadFileHelper.SaveFile(patient.PhotoUrl, "Photos");
            var user = await userManager.FindByIdAsync(OldData.UserId);
            user.Email = patient.Email;
            user.UserName = patient.Email;
            var result = await userManager.UpdateAsync(user);
            await db.SaveChangesAsync();
            return 0;
        }
        #endregion

        #region Delete Patient
        public bool Delete(int id)
        {
            try
            {
                var data = db.Patients.Where(x => x.Id == id).FirstOrDefault();
                data.IsActive = true;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }
        #endregion




    }
}
