using DAL.Database;
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


        //public async Task<string> GetUserName(string Email)
        //{
        //    var User= userManager.FindByEmailAsync(Email);
        //    string UserId = User.;

        //    var UserEmail = await userManager.FindByEmailAsync(Email);
        //    var UserRole = await userManager.GetRolesAsync(UserEmail);
        //    if (UserRole[0]=="Admin"|| UserRole[0] == "Doctor")
        //    {
        //       db.Doctors.Where(x=>x.UserId==User.Id)
        //    }
        //    else if (UserRole[0] == "Receptionist")
        //    {

                
        //    }

        //    else if (UserRole[0] == "AnalysisDoctor")
        //    {

                
        //    }
        //    else if (UserRole[0] == "RadiologyDoctor")
        //    {

                
        //    }
        //    else if (UserRole[0] == "Pharmacist")
        //    {

              
        //    }
        //    else
        //    {
             

        //    }
        //}

    

            
        
    }
}
