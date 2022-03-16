using AutoMapper;
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

namespace BLL.Services.EmplyeeServices
{
   public class EmplyeeServices : IEmplyeeServices
    {
       
        private UserManager<IdentityUser> userManager;
        private readonly AplicationDbContext db;

        public EmplyeeServices(UserManager<IdentityUser> userManager, AplicationDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }
        public async Task<bool> Add(EmplyeeViewModel emp)
        {
            
            Emplyee obj = new Emplyee();
            obj.Name = emp.Name;
            obj.SSN = emp.SSN;
            obj.BirthDate = emp.BirthDate;
            obj.Gender = emp.Gender;
            obj.Phone = emp.Phone;
            obj.Photo = UploadFileHelper.SaveFile(emp.PhotoUrl, "Photos");

            var user = new IdentityUser()
            {
                Email = emp.Email,
                UserName = emp.Email,
            };
            var result =await userManager.CreateAsync(user, emp.Password);
            var user2 = await userManager.FindByEmailAsync(emp.Email);
            //var result2 = await userManager.AddToRoleAsync(user2, "Employee");
            if (result.Succeeded/*&& result2.Succeeded*/)
            {
                //
                obj.UserId = user2.Id;
                //obj.UserId =  userManager.FindByEmailAsync(emp.Email).Result.Id;
                await db.Emplyees.AddAsync(obj);
                int res = await db.SaveChangesAsync();
                if (res>0)
                {
                    return true;
                }

                return false;
            }
            return false;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<EmplyeeViewModel> Get()
        {
            throw new NotImplementedException();
        }

        public EmplyeeViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(EmplyeeViewModel EmplyeeViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
