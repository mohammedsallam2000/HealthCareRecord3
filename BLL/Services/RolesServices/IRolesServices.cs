using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.RolesServices
{
    public interface IRolesServices
    {
        Task<bool> Create(IdentityRole model);
        IQueryable<IdentityRole> GetAll();
        Task<IdentityRole> GetByID(string id);
        Task<bool> Edit(IdentityRole model);
        Task<bool> Delete(string id);
        Task<bool> EditUserInRole(List<UserInRoleViewModel> model, string id);
    }
}
