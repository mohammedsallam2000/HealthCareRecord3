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
        #region Fields
        private UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly AplicationDbContext db;
        #endregion

        #region Ctor
        public PatientServices(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, AplicationDbContext db)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.db = db;
        }
        #endregion

        #region Create New Patient
        public async Task<int> Add(PatientViewModel patient)
        {
            try
            {
                Patient obj = new Patient();
                //mapping
                obj.Name = patient.Name;
                obj.SSN = patient.SSN;
                obj.BirthDate = patient.BirthDate;
                obj.Gender = patient.Gender;
                obj.Phone = patient.Phone;
                obj.AnotherPhone = patient.AnotherPhone;
                obj.Address = patient.Address;
                obj.AnotherPhone = patient.AnotherPhone;
                obj.LogInTime = DateTime.Now;
                if (patient.PhotoUrl != null)
                {
                    obj.photo = UploadFileHelper.SaveFile(patient.PhotoUrl, "Photos");
                }
                obj.LogInTime = DateTime.Now;

                var user = new IdentityUser()
                {
                    Email = (patient.SSN),
                    UserName = (patient.SSN),
                };
                var result = await userManager.CreateAsync(user, patient.SSN);
                var user2 = await userManager.FindByEmailAsync(patient.SSN);
                //Create Role Patient if not found
                var TestRole = await roleManager.RoleExistsAsync("Patient");
                if (!TestRole)
                {
                    var role = new IdentityRole { Name = "Patient" };
                    await roleManager.CreateAsync(role);
                }
                // Put patient in patient role
                var result2 = await userManager.AddToRoleAsync(user2, "Patient");
                if (result.Succeeded && result2.Succeeded)
                {
                    obj.UserId = user2.Id;
                    await db.Patients.AddAsync(obj);
                    int res = await db.SaveChangesAsync();
                    if (res > 0)
                    {
                        return obj.Id;
                    }
                    return 0;
                }
                else
                {
                    return 0;
                }
                
            }
            catch (Exception)
            {
                return 0;
            }
            
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

        #region Get Patient By Id
        public async Task<PatientViewModel> GetByID(int id)
        {
            //Select User Id of the patient From Patient table
            var user = await userManager.FindByIdAsync(db.Patients.Where(x => x.Id == id).Select(x => x.UserId).FirstOrDefault());
            // Select Patient by his id
            var patient = db.Patients.Where(x => x.Id == id)
                                    .Select(x => new PatientViewModel
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        Address = x.Address,
                                        BirthDate = x.BirthDate,
                                        Phone = x.Phone,
                                        AnotherPhone = x.AnotherPhone,
                                        SSN = x.SSN,
                                        photo = x.photo,
                                        Gender = x.Gender,
                                        UserId = x.UserId,
                                        Email = user.Email,
                                        LogInTime = x.LogInTime,
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

        #region Check SSN is Uniq or not
        public bool SSNUnUsed(string ssn)
        {
            var Ssn = db.Patients.Where(x => x.SSN == ssn).FirstOrDefault();
            if (Ssn != null)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Get Patient By his SSN
        public PatientViewModel GetBySSN(string SSN)
        {
            // Select Patient by his ssn 
            var patient = db.Patients.Where(x => x.SSN == SSN)
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
                                        LogInTime = x.LogInTime,
                                        IsActive = x.IsActive
                                    })
                                    .FirstOrDefault();
            return patient;
        }
        #endregion

        #region Get Patient Id By his userId
        public int PatiantId(string UserId)
        {
            var id = db.Patients.Where(x => x.UserId == UserId).Select(x => x.Id).FirstOrDefault();
            return id;
        }

        #endregion
    }
}
