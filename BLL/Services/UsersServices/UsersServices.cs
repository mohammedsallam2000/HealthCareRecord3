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

        public UsersServices(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
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
    }
}
