using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.UsersServices
{
    public interface IUsersServices
    {
        IQueryable<IdentityUser> GetAll();
        Task<IdentityUser> GetByID(string id);
        Task<bool> Edit(IdentityUser model);

        Task<bool> Delete(string id);
         Task<LoginUserDataViewModel> GetUserName(string Email);
    }
}
