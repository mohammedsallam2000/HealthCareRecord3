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
            obj.Address = emp.Address;
            obj.ShiftId = emp.ShiftId;
            obj.Photo = UploadFileHelper.SaveFile(emp.PhotoUrl, "Photos");

            var user = new IdentityUser()
            {
                Email = emp.Email,
                UserName = emp.Email,
            };
            var result = await userManager.CreateAsync(user, emp.Password);
            var user2 = await userManager.FindByEmailAsync(emp.Email);
            //var result2 = await userManager.AddToRoleAsync(user2, "Employee");
            if (result.Succeeded/*&& result2.Succeeded*/)
            {
                //
                obj.UserId = user2.Id;
                //obj.UserId =  userManager.FindByEmailAsync(emp.Email).Result.Id;
                await db.Emplyees.AddAsync(obj);
                int res = await db.SaveChangesAsync();
                if (res > 0)
                {
                    return true;
                }

                return false;
            }
            return false;
        }

        public IEnumerable<EmplyeeViewModel> GetAll()
        {
            //List<EmplyeeViewModel> emp = new List<EmplyeeViewModel>();
            //foreach (var item in db.Emplyees)
            //{
            //    EmplyeeViewModel obj = new EmplyeeViewModel();
            //    obj.Address = item.Address;
            //    obj.BirthDate = item.BirthDate;
            //    obj.Gender = item.Gender;
            //    obj.Name = item.Name;
            //    obj.Phone = item.Phone;
            //    obj.SSN = item.SSN;
            //    obj.WorkStartTime = item.WorkStartTime;
            //    obj.Photo = item.Photo;
            //    obj.Id = item.Id;
            //}
            //return emp;
            return db.Emplyees
                       .Select(x => new EmplyeeViewModel { Id = x.Id, Name = x.Name,  Address = x.Address, WorkStartTime = x.WorkStartTime, 
                       BirthDate = x.BirthDate, Phone = x.Phone, SSN = x.SSN, Photo = x.Photo, Gender = x.Gender});
        }

        public async Task<EmplyeeViewModel> GetByID(int id)
        {
            var user = await userManager.FindByIdAsync(db.Emplyees.Where(x => x.Id == id).Select(x => x.UserId).FirstOrDefault());
            var emp = db.Emplyees.Where(x => x.Id == id)
                                    .Select(x => new EmplyeeViewModel {
                                        Id = x.Id,
                                        Name = x.Name,
                                        Address = x.Address,
                                        WorkStartTime = x.WorkStartTime,
                                        BirthDate = x.BirthDate,
                                        Phone = x.Phone,
                                        SSN = x.SSN,
                                        Photo = x.Photo,
                                        Gender = x.Gender,
                                        UserId = x.UserId,
                                        Email = user.Email
                                    })
                                    .FirstOrDefault();
            return  emp;
        }

        public async Task<int> Edit(EmplyeeViewModel emp)
        {
            var OldData = db.Emplyees.FirstOrDefault(x => x.Id == emp.Id);
            OldData.Name = emp.Name;
            OldData.BirthDate = emp.BirthDate;
            OldData.Gender = emp.Gender;
            OldData.ShiftId = emp.ShiftId;
            OldData.Address = emp.Address;
            OldData.Phone = emp.Phone;
            //OldData.Photo = UploadFileHelper.SaveFile(doc.PhotoUrl, "Photos");
            var user = await userManager.FindByIdAsync(OldData.UserId);
            user.Email = emp.Email;
            user.UserName = emp.Email;
            var result = await userManager.UpdateAsync(user);
            await db.SaveChangesAsync();
            return 0;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
    }
