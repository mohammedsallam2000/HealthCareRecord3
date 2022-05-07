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

namespace BLL.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly AplicationDbContext context;
        private UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public DoctorService(AplicationDbContext context , UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.context = context;
        } 
        public async Task<int> Add(DoctorViewModel doc)
        {

                Doctor obj = new Doctor();
                obj.Name = doc.Name;
                obj.SSN = doc.SSN;
                obj.Phone = doc.Phone;
                obj.Address = doc.Address;
                obj.ShiftId = doc.ShiftId;
                obj.BirthDate = doc.BirthDate;
                obj.Degree = doc.Degree;            
                obj.Gender = doc.Gender;
            obj.IsActive = false;

            obj.DepartmentId = doc.DepartmentId;
                obj.Photo = UploadFileHelper.SaveFile(doc.PhotoUrl, "Photos");
                var user = new IdentityUser()
                {
                    Email = doc.Email,
                    UserName = doc.Email,
                };
                var result = await userManager.CreateAsync(user, doc.Password);
                var user2 = await userManager.FindByEmailAsync(doc.Email);
            var DepartmentName = context.Departments.Where(x => x.DepartmentId == doc.DepartmentId).Select(x => x.Name).FirstOrDefault();
                if (DepartmentName == "Analysis")
                {
                //Create Role LabDoctor if not found
                var TestRole = await roleManager.RoleExistsAsync("AnalysisDoctor");
                if (!TestRole)
                {
                    var role = new IdentityRole { Name = "AnalysisDoctor" };
                    await roleManager.CreateAsync(role);
                }
                // put LabDoctor in LabDoctor role
                var result2 = await userManager.AddToRoleAsync(user2, "AnalysisDoctor");
                }
                else if(DepartmentName == "Radiology")
                {
                //Create Role RadiologyDoctor if not found
                var TestRole = await roleManager.RoleExistsAsync("RadiologyDoctor");
                if (!TestRole)
                {
                    var role = new IdentityRole { Name = "RadiologyDoctor" };
                    await roleManager.CreateAsync(role);
                }
                // put RadiologyDoctor in RadiologyDoctor role
                var result2 = await userManager.AddToRoleAsync(user2, "RadiologyDoctor");
                }
                else if (DepartmentName == "Pharmacy")
                {
                    //Create Role Pharmacist if not found
                    var TestRole = await roleManager.RoleExistsAsync("Pharmacist");
                    if (!TestRole)
                    {
                        var role = new IdentityRole { Name = "Pharmacist" };
                        await roleManager.CreateAsync(role);
                    }
                    // put Pharmacist in Pharmacist role
                    var result2 = await userManager.AddToRoleAsync(user2, "Pharmacist");
                }
                else
                {
                    //Create Role Doctor if not found
                    var TestRole = await roleManager.RoleExistsAsync("Doctor");
                    if (!TestRole)
                    {
                        var role = new IdentityRole { Name = "Doctor" };
                        await roleManager.CreateAsync(role);
                    }
                    // put Doctor in Doctor role
                    var result2 = await userManager.AddToRoleAsync(user2, "Doctor");
                }
                if (result.Succeeded)
                {
                    obj.UserId = user2.Id;
                    await context.Doctors.AddAsync(obj);
                    int res = await context.SaveChangesAsync();
                    if (res > 0)
                    {
                        return obj.Id;
                    }
                    return 0;
                }
                return 0;
        }
        public async Task<int> Update(DoctorViewModel doc)
        {
            var OldData = context.Doctors.FirstOrDefault(x => x.Id == doc.Id);
                OldData.Name = doc.Name;
                OldData.BirthDate = doc.BirthDate;
            //OldData.Gender = doc.Gender;
            OldData.ShiftId = doc.ShiftId;
            OldData.Address = doc.Address;
            //OldData.Phone = doc.Phone;
            //OldData.Photo = UploadFileHelper.SaveFile(doc.PhotoUrl, "Photos");
            var user = await userManager.FindByIdAsync(OldData.UserId);
                user.Email = doc.Email;
                user.UserName = doc.Email;
                var result = await userManager.UpdateAsync(user);
                await context.SaveChangesAsync();
                return 0;
           
        }




        public async Task <bool> Delete(int id)
        {
            try
            {

                var DeletedObject = context.Doctors.FirstOrDefault(x => x.Id == id);
                //UploadFileHelper.RemoveFile("Photos/", DeletedObject.Photo);
                //context.Doctors.Remove(DeletedObject);
                DeletedObject.IsActive = true;
                var user = await userManager.FindByIdAsync(DeletedObject.UserId);
                await userManager.DeleteAsync(user);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    
       

        public IEnumerable<DoctorViewModel> GetAll()
        {
            List<DoctorViewModel> doc = new List<DoctorViewModel>();
            foreach (var item in context.Doctors.Where(x=>x.IsActive==false))
            {
                DoctorViewModel obj = new DoctorViewModel();
                obj.Address = item.Address;
                obj.BirthDate = item.BirthDate;
                obj.Degree = item.Degree;
                obj.Gender = item.Gender;
                obj.Name = item.Name;
                obj.Phone = item.Phone;
                obj.DepartmentName = context.Departments.Where(x => x.DepartmentId == item.DepartmentId).Select(x => x.Name).FirstOrDefault();
                obj.SSN = item.SSN;
                obj.WorkStartTime = item.WorkStartTime;
                obj.Photo = item.Photo;
                obj.Id = item.Id;
                doc.Add(obj);
            }
            return doc;
        }

        public async  Task<DoctorViewModel> GetByID(int id)
        {
            var user = await userManager.FindByIdAsync(context.Doctors.Where(x => x.Id == id).Select(x => x.UserId).FirstOrDefault());
                Doctor doc = context.Doctors.FirstOrDefault(x => x.Id ==id);
                DoctorViewModel obj = new DoctorViewModel();
                obj.Address = doc.Address;
                obj.BirthDate = doc.BirthDate;
                obj.Degree = doc.Degree;
                obj.Gender = doc.Gender;
                obj.Name = doc.Name;
                obj.Email = user.Email;
                obj.Phone = doc.Phone;
                obj.SSN = doc.SSN;
                obj.WorkStartTime = doc.WorkStartTime;
                obj.Photo = doc.Photo;
                obj.Id = doc.Id;
                return obj;
        }

      
        public IEnumerable<DoctorViewModel> GetAll(int id, int ShiftId)
        {
            List<DoctorViewModel> doc = new List<DoctorViewModel>();
            foreach (var item in context.Doctors.Where(x => x.DepartmentId == id && x.ShiftId == ShiftId))
            {
                DoctorViewModel obj = new DoctorViewModel();
                obj.Address = item.Address;
                obj.BirthDate = item.BirthDate;
                obj.Degree = item.Degree;
                obj.Gender = item.Gender;
                obj.Name = item.Name;
                obj.Phone = item.Phone;
                obj.SSN = item.SSN;
                obj.WorkStartTime = item.WorkStartTime;
                obj.Photo = item.Photo;
                obj.Id = item.Id;
                doc.Add(obj);
            }
            return doc;
        }

        public bool SSNUnUsed(string ssn)
        {
            var Ssn=context.Doctors.Where(x=>x.SSN==ssn).FirstOrDefault();
            if (Ssn!=null)
            {
                return false;
            }
            return true;
        }
    }
}
