using DAL.Database;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.UsersServices
{
    public class UsersServices : IUsersServices
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly AplicationDbContext db;

        public UsersServices(UserManager<IdentityUser> userManager, AplicationDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }

        public async Task<bool> Delete(string id)
        {

            try
            {
                var user = await GetByID(id);
                if (user != null)
                {
                    var result = await userManager.DeleteAsync(user);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Edit(IdentityUser model)
        {
            try
            {
                var user = await GetByID(model.Id);
                if (user != null)
                {
                    user.UserName = model.UserName;
                    user.Email = model.UserName;
                    var result = await userManager.UpdateAsync(user);
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception)
            {
                return true;
            }
           
        }

        public IQueryable<IdentityUser> GetAll()
        {
            var users = userManager.Users;
            return users;
        }

        public async Task<IdentityUser> GetByID(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            return user;
        }


        public async Task<LoginUserDataViewModel> GetUserName(string Email)
        {
            LoginUserDataViewModel obj = new LoginUserDataViewModel();
            var UserEmail = await userManager.FindByEmailAsync(Email);
            var user = UserEmail.Id;
            var UserRole = await userManager.GetRolesAsync(UserEmail);
            if (UserRole[0] == "Admin" || UserRole[0] == "Doctor" || UserRole[0] == "AnalysisDoctor" || UserRole[0] == "RadiologyDoctor" || UserRole[0] == "Pharmacist")
            {
                var DoctorData = db.Doctors.Where(x => x.UserId == user).Select(x=>new LoginUserDataViewModel
                {
                    Name=x.Name,
                    Photo=x.Photo
                }).FirstOrDefault();

                //obj.Name = DoctorData.Name;
                //obj.Photo = DoctorData.Photo;
                return DoctorData;
            }
            else if (UserRole[0] == "Receptionist")
            {
                var ReceptionData = db.Emplyees.Where(x => x.UserId == user).Select(x => new LoginUserDataViewModel
                {
                    Name = x.Name,
                    Photo = x.Photo
                }).FirstOrDefault();
                return ReceptionData;

            }
            else if (UserRole[0] == "Patient")
            {
                var ReceptionData = db.Patients.Where(x => x.UserId == user).Select(x => new LoginUserDataViewModel
                {
                    id=x.Id,
                    Name = x.Name,
                    Photo = x.photo
                }).FirstOrDefault();
                return ReceptionData;

            }
            else
            {
                var DoctorData = db.Doctors.Where(x => x.UserId == user).Select(x => new LoginUserDataViewModel
                {
                    Name = x.Name,
                    Photo = x.Photo
                }).FirstOrDefault();
                return DoctorData;
            }

        }
       

    }
}
