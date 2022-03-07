using AutoMapper;
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
    class EmplyeeServices : IEmplyeeServices
    {
        private readonly AplicationDbContext db;
        private UserManager<IdentityUser> userManager;
        public EmplyeeServices(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        public void Add(EmplyeeViewModel emp)
        {
            //AplicationDbContext context = new AplicationDbContext();
            //Emplyee obj = new Emplyee();
            //obj.Name = emp.Name;
            //obj.SSN = emp.SSN;
            //obj.BirthDate = emp.BirthDate;
            //obj.Gender = emp.Gender;
            //obj.Phone = emp.Phone;    
            //context.Emplyees.Where(x=>x.UserId == IdentityUser.)
            //var user = new IdentityUser()
            //{
            //    Email = emp.,
            //    UserName = emp.Email,
            //};

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
