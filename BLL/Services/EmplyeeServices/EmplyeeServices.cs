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
        #region Fields 
        private UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly AplicationDbContext db;
        #endregion

        #region Ctor
        public EmplyeeServices(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, AplicationDbContext db)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.db = db;
        }
        #endregion

        #region Create New Emplyee
        public async Task<int> Add(EmplyeeViewModel emp)
        {
            try
            {
                Emplyee obj = new Emplyee();
                obj.Name = emp.Name;
                obj.SSN = emp.SSN;
                obj.BirthDate = emp.BirthDate;
                obj.Gender = emp.Gender;
                obj.Phone = emp.Phone;
                obj.Address = emp.Address;
                obj.ShiftId = emp.ShiftId;
                obj.Facebook = emp.Facebook;
                obj.Twitter = emp.Twitter;
                obj.Whatsapp = emp.Whatsapp;
                if(emp.PhotoUrl != null)
                {
                    obj.Photo = UploadFileHelper.SaveFile(emp.PhotoUrl, "Photos");
                }
                var user = new IdentityUser()
                {
                    Email = emp.Email,
                    UserName = emp.Email,
                };
                var result = await userManager.CreateAsync(user, emp.Password);
                var user2 = await userManager.FindByEmailAsync(emp.Email);
                // Receptionst
                //Create Role Receptionist if not found
                var TestRole = await roleManager.RoleExistsAsync("Receptionist");
                if (!TestRole)
                {
                   var role =  new IdentityRole { Name = "Receptionist" };
                   await roleManager.CreateAsync(role);
                }
                // put Receptionst in Receptionst role
                var result2 = await userManager.AddToRoleAsync(user2, "Receptionist");
                if (result.Succeeded && result2.Succeeded)
                {
                    obj.UserId = user2.Id;
                    obj.UserId =  userManager.FindByEmailAsync(emp.Email).Result.Id;
                    await db.Emplyees.AddAsync(obj);
                    int res = await db.SaveChangesAsync();
                    if (res > 0)
                    {
                        return 1;
                    }

                    return 0;
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion

        #region Get All Emplyees
        public IEnumerable<EmplyeeViewModel> GetAll()
        {
            try
            {
                return db.Emplyees
                .Where(x => x.IsActive == false)
                       .Select(x => new EmplyeeViewModel
                       {
                           Id = x.Id,
                           Name = x.Name,
                           Address = x.Address,
                           WorkStartTime = x.WorkStartTime,
                           BirthDate = x.BirthDate,
                           Phone = x.Phone,
                           SSN = x.SSN,
                           Photo = x.Photo,
                           Gender = x.Gender
                       });
            }
            catch (Exception)
            {
                throw;
            }        
        }
        #endregion

        #region Get Emplyee By his Id
        public async Task<EmplyeeViewModel> GetByID(int id)
        {
            var user = await userManager.FindByIdAsync(db.Emplyees.Where(x => x.Id == id).Select(x => x.UserId).FirstOrDefault());
            var emp = db.Emplyees.Where(x => x.Id == id)
                                    .Select(x => new EmplyeeViewModel
                                    {
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
                                        Facebook = x.Facebook,
                                        Twitter = x.Twitter,
                                        Whatsapp = x.Whatsapp,
                                        Email = user.Email
                                    })
                                    .FirstOrDefault();
            return emp;
        }

        #endregion

        #region Edit Emplyee
        public async Task<int> EditAccountInfo(EmplyeeViewModel emp)
        {
            try
            {
                var OldData = db.Emplyees.FirstOrDefault(x => x.Id == emp.Id);
                //OldData.Facebook = emp.Facebook;
                //OldData.Twitter = emp.Twitter;
                //OldData.Whatsapp = emp.Whatsapp;
                OldData.Phone = emp.Phone;
                var user = await userManager.FindByIdAsync(OldData.UserId);
                user.Email = emp.Email;
                
                user.UserName = emp.Email;
                var result = await userManager.UpdateAsync(user);
                await db.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }
        public async Task<int> EditBasicInfo(EmplyeeViewModel emp)
        {
            try
            {
                var OldData = db.Emplyees.FirstOrDefault(x => x.Id == emp.Id);
                OldData.Name = emp.Name;
                OldData.BirthDate = emp.BirthDate;
                OldData.Address = emp.Address;
                await db.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        #endregion

        #region Delete Emplyee
        public bool Delete(int id)
        {
            try
            {
                var data = db.Emplyees.Where(x => x.Id == id).FirstOrDefault();
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
            var Ssn = db.Emplyees.Where(x => x.SSN == ssn).FirstOrDefault();
            if (Ssn != null)
            {
                return false;
            }
            return true;
        }

        #endregion 
    }
}
