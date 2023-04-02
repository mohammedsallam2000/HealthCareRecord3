using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;
using DAL.Models.vacation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Services._1Vacation.VacationServices.UserVacation
{
    public class UserVacation : IUserVacation
    {
        private readonly AplicationDbContext db;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserVacation(AplicationDbContext db, RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            this.roleManager = roleManager;
        }
        public class userinfo{
            public int id { get; set; }
            public string UserId { get; set; }
            public int? vacationBlance { get; set; }

            public string Name { get; set; }

        }
        public IEnumerable <userinfo> GetUserinfo(string id,string UserId, List<string> name)
        {
           List<userinfo> user = new List<userinfo>();
            
            if (id == "Doctor" || id == "AnalysisDoctor" || id == "RadiologyDoctor" || id == "Pharmacist")
            {
                if (UserId!=null)
                {
                    userinfo obj = new userinfo();

                    var data = db.Doctors.Where(x => x.UserId == UserId).FirstOrDefault();
                    obj.id = data.Id;
                    obj.Name = data.Name;
                    obj.UserId = data.UserId;
                    
                    obj.vacationBlance = data.VacationBalance;

                    user.Add(obj);

                }
                else
                {

                    var data = db.Doctors.ToList();
                    foreach (var item in data)
                    {
                        foreach (var item1 in name)
                        {
                            if (item.Name==item1)
                            {
                                userinfo obj = new userinfo();

                                obj.id = item.Id;
                                obj.Name = item.Name;
                                obj.UserId = item.UserId;
                                obj.vacationBlance = item.VacationBalance;
                                user.Add(obj);
                            }
                            
                        }
                        


                        
                    }
                   

                }





            }
            else if (id == "Receptionist")
            {
                if (UserId != null)
                {
                    userinfo obj = new userinfo();

                    var data = db.Emplyees.Where(x => x.UserId == UserId).FirstOrDefault();
                    obj.id = data.Id;
                    obj.Name = data.Name;
                    obj.UserId = data.UserId;
                    obj.vacationBlance = data.VacationBalance;


                    user.Add(obj);
                }
                else
                {
                    var data = db.Emplyees.ToList();
                    foreach (var item in data)
                    {
                        userinfo obj = new userinfo();

                        obj.id = item.Id;
                        obj.Name = item.Name;
                        obj.UserId = item.UserId;
                        obj.vacationBlance = item.VacationBalance;


                        user.Add(obj);
                    }

                }

                

            }
            else if (id == "Nurse")
            {
                if (UserId != null)
                {
                    userinfo obj = new userinfo();

                    var data = db.Nurses.Where(x => x.UserId == UserId).FirstOrDefault();
                    obj.id = data.Id;
                    obj.Name = data.Name;
                    obj.UserId = data.UserId;
                    obj.vacationBlance = data.VacationBalance;


                    user.Add(obj);
                }
                else
                {

                    var data = db.Nurses.ToList();
                    foreach (var item in data)
                    {
                        userinfo obj = new userinfo();

                        obj.id = item.Id;
                        obj.Name = item.Name;
                        obj.UserId = item.UserId;
                        obj.vacationBlance = item.VacationBalance;


                        user.Add(obj);
                    }

                }

               

            }
            else
            {
                if (UserId != null)
                {
                    userinfo obj = new userinfo();

                    var data = db.Emplyees.Where(x => x.UserId == UserId).FirstOrDefault();
                    obj.id = data.Id;
                    obj.Name = data.Name;
                    obj.UserId = data.UserId;
                    obj.vacationBlance = data.VacationBalance;


                    user.Add(obj);

                }
                else
                {
                    var data = db.Emplyees.ToList();
                    foreach (var item in data)
                    {
                        userinfo obj = new userinfo();

                        obj.id = item.Id;
                        obj.Name = item.Name;
                        obj.UserId = item.UserId;
                        obj.vacationBlance = item.VacationBalance;


                        user.Add(obj);
                    }

                }

               

            }

            return user;
        }

        public async Task< UserVacationSum> GetAll(UserVacationSum model, List<string> name)
        {
            var role = await roleManager.FindByIdAsync(model.DepartmentId);

           UserVacationSum list = new UserVacationSum();
            var data = GetUserinfo(role.Name, model.userId,name);
            list.enddate = model.enddate;
            list.startdate = model.startdate;
            list.DepartmentId = model.DepartmentId;
            List<userVacationSums> days =new List<userVacationSums>();
            foreach (var item in data)
            {

                userVacationSums obj = new userVacationSums();
                var data1 = db.RequestVacations.Where(x => x.UserId == item.UserId).Include(x => x.VacationType).Include(x=>x.vacationPlans).Where(x=>x.Approved==true) ;
                int sum=0 ;
                int sum1 = 0;
                if (data1 != null)
                {
                    var date1 = DateTime.Now.Year;
                    foreach (var item1 in data1)
                    {


                        foreach (var item2 in item1.vacationPlans)
                        {
                            if (model.startdate<=item2.VacationDate&& item2.VacationDate <= model.enddate)
                            {
                                sum1 = sum1 + (item1.VacationType.NumberDays );

                            }
                            if (item2.VacationDate.Year==date1)
                            {
                                sum = sum + (item1.VacationType.NumberDays);

                            }
                        }
                        

                    }
                }
                else
                {

                }

                obj.TotalVacationDays = sum;
                obj.TotalVacationDaysinTime = sum1;
                obj.UserName = item.Name;
                
                obj.UserVacationDays = item.vacationBlance;
                obj.RemingVacationDays = (int)(item.vacationBlance - obj.TotalVacationDays);
                days.Add(obj);










            }
            list.userVacationSums= days;
            
            return list;
        }

        public IEnumerable<UserVacationSum> GetAll(DateTime startdate, DateTime enddate, string UserId)
        {
            throw new NotImplementedException();
        }
    }
}
