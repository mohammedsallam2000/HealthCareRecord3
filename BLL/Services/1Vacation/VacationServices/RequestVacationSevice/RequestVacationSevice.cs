using AutoMapper;
using DAL.Database;
using DAL.Entities.vacation;
using DAL.Models.vacation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services._1Vacation.VacationServices.RequestVacationSevice
{
    public class RequestVacationSevice : IRequestVacationSevice
    {
        private readonly AplicationDbContext db;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMapper mapper;

        public RequestVacationSevice(AplicationDbContext db, UserManager<IdentityUser> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public bool Add(VacationPlainViewModel model, int[] DoyOfWeekCheeked)
        {
            var result = db.vacationPlans.Where(x => x.RequestVacation.UserId == model.RequestVacationViewModel.UserId &&
            x.VacationDate >= model.RequestVacationViewModel.StartDate && x.VacationDate <= model.RequestVacationViewModel.EndDate).FirstOrDefault();
            try
            {
                vacationPlan vacationPlan = new vacationPlan();
                for (DateTime date = model.RequestVacationViewModel.StartDate; date <= model.RequestVacationViewModel.EndDate; date = date.AddDays(1))
                {


                    if (Array.IndexOf(DoyOfWeekCheeked, (int)date.DayOfWeek) != -1)
                    {
                        //vacationPlan.VacationDate = date;
                        vacationPlan.RequestVacation.RequestDate = DateTime.Now;
                        db.vacationPlans.Add(vacationPlan);
                        db.SaveChanges();



                        //obj.VacationDate= date;
                        //obj.RequestVacation.RequestDate = DateTime.Now;
                        //db.vacationPlans.Add(obj);

                    }


                }
                return true;

            }
            catch (Exception)
            {

                return false;
            }
           
            
        }

        public bool Delete(int id)
        {
            try
            {
                var data = db.RequestVacations.FirstOrDefault(x => x.Id == id);
                db.RequestVacations.Remove(data);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           

        }

        public async Task<IEnumerable<RequestVacationViewModel>> GetAllAsync()
        {
            List<RequestVacationViewModel> list = new List<RequestVacationViewModel>();
            var data = db.RequestVacations.Include(x => x.VacationType).OrderByDescending(x => x.RequestDate).ToList();
            foreach (var item in data)
            {
                
                RequestVacationViewModel Request=new RequestVacationViewModel();
                Request.Id = item.Id;
                Request.UserId = item.UserId;
                Request.Approved=item.Approved;
                Request.DataApproved=item.DataApproved;
                Request.EndDate=item.EndDate;
                string datal = item.VacationType.Background;
                Request.Comment = datal;

                Request.StartDate=item.StartDate;
                Request.RequestDate=item.RequestDate;
                Request.Comment = item.Comment;
                Request.vacationPlans = item.vacationPlans;
                
               
                //userinfo.Name=

                
            var user = await userManager.FindByIdAsync(item.UserId);

                var UserRole = await userManager.GetRolesAsync(user);
                if ( UserRole[0] == "Doctor" || UserRole[0] == "AnalysisDoctor" || UserRole[0] == "RadiologyDoctor" || UserRole[0] == "Pharmacist")
                {
                   Request.userinfos.Name  = db.Doctors.Where(x => x.UserId == item.UserId).Select(x => x.Name).FirstOrDefault();

                    Request.userinfos.Department = UserRole[0];


                    
                }
                else if( UserRole[0] == "Receptionist")
                {
                    Request.userinfos.Name = db.Emplyees.Where(x => x.UserId == item.UserId).Select(x => x.Name).FirstOrDefault();

                    Request.userinfos.Department = UserRole[0];

                }
                else if (UserRole[0] == "Nurse")
                {
                    Request.userinfos.Name = db.Nurses.Where(x => x.UserId == item.UserId).Select(x => x.Name).FirstOrDefault();

                    Request.userinfos.Department = UserRole[0];

                }
                else
                {
                    Request.userinfos.Name = db.Emplyees.Where(x => x.UserId == item.UserId).Select(x => x.Name).FirstOrDefault();

                    Request.userinfos.Department = UserRole[0];

                }

                Request.VacationType.Background = item.VacationType.Background;
                Request.VacationType.VacationName = item.VacationType.VacationName;
                Request.VacationType.NumberDays = item.VacationType.NumberDays;




                list.Add(Request);


            }
            var a = data;
            return list;


        }
        public async Task<string> user(string userId)
        {
            string UserName = null;
            var user = await userManager.FindByIdAsync(userId);

            var UserRole = await userManager.GetRolesAsync(user);
            if (UserRole[0] == "Doctor" || UserRole[0] == "AnalysisDoctor" || UserRole[0] == "RadiologyDoctor" || UserRole[0] == "Pharmacist")
            {
                UserName = db.Doctors.Where(x => x.UserId == userId).Select(x => x.Name).FirstOrDefault();




            }
            else if (UserRole[0] == "Receptionist")
            {
                UserName = db.Emplyees.Where(x => x.UserId == userId).Select(x => x.Name).FirstOrDefault();


            }
            else if (UserRole[0] == "Nurse")
            {
                UserName = db.Nurses.Where(x => x.UserId == userId).Select(x => x.Name).FirstOrDefault();

                

            }
            else
            {
                UserName = db.Emplyees.Where(x => x.UserId == userId).Select(x => x.Name).FirstOrDefault();

               

            }

            return UserName;
        }

        public async Task< RequestVacationViewModel> GetByID(int id)
        {

            List<RequestVacationViewModel> list = new List<RequestVacationViewModel>();
            var item = db.RequestVacations.Where(x=>x.Id==id).Include(x => x.VacationType).Include(x=>x.vacationPlans).OrderByDescending(x => x.RequestDate).FirstOrDefault();
            

                RequestVacationViewModel Request = new RequestVacationViewModel();
                Request.Id = item.Id;
                Request.UserId = item.UserId;
                Request.Approved = item.Approved;
                Request.DataApproved = item.DataApproved;
                Request.EndDate = item.EndDate;
                string datal = item.VacationType.Background;
                Request.Comment = datal;

                Request.StartDate = item.StartDate;
                Request.RequestDate = item.RequestDate;
                Request.Comment = item.Comment;
                Request.vacationPlans = item.vacationPlans;


                //userinfo.Name=


                var user = await userManager.FindByIdAsync(item.UserId);

                var UserRole = await userManager.GetRolesAsync(user);
                if (UserRole[0] == "Doctor" || UserRole[0] == "AnalysisDoctor" || UserRole[0] == "RadiologyDoctor" || UserRole[0] == "Pharmacist")
                {
                    Request.userinfos.Name = db.Doctors.Where(x => x.UserId == item.UserId).Select(x => x.Name).FirstOrDefault();

                    Request.userinfos.Department = UserRole[0];



                }
                else if (UserRole[0] == "Receptionist")
                {
                    Request.userinfos.Name = db.Emplyees.Where(x => x.UserId == item.UserId).Select(x => x.Name).FirstOrDefault();

                    Request.userinfos.Department = UserRole[0];

                }
                else if (UserRole[0] == "Nurse")
                {
                    Request.userinfos.Name = db.Nurses.Where(x => x.UserId == item.UserId).Select(x => x.Name).FirstOrDefault();

                    Request.userinfos.Department = UserRole[0];

                }
                else
                {
                    Request.userinfos.Name = db.Emplyees.Where(x => x.UserId == item.UserId).Select(x => x.Name).FirstOrDefault();

                    Request.userinfos.Department = UserRole[0];

                }

                Request.VacationType.Background = item.VacationType.Background;
                Request.VacationType.VacationName = item.VacationType.VacationName;
                Request.VacationTypeId = item.VacationType.Id;

            Request.VacationType.NumberDays = item.VacationType.NumberDays;
            Request.vacationPlans = item.vacationPlans;
            


            return Request;
        }

        public bool Update(RequestVacationViewModel model)
        {
            try
            {
                var data = db.RequestVacations.Where(x => x.Id == model.Id).FirstOrDefault();
                if (data.Approved==true)
                {
                    data.DataApproved = DateTime.Now;
                }
                
                data.Approved = model.Approved;
                data.Comment = model.Comment;
                data.VacationTypeId = model.VacationTypeId;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           

        }
    }

       
    
}
