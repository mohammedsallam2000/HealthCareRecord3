using DAL.Database;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.DoctorWork.DoctorPatiant
{
    public class PatiantDoctor : IPatiantDoctor
    {
        private readonly AplicationDbContext db;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public PatiantDoctor(AplicationDbContext db,SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager)
        {

            this.db = db;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        #region انهاء الكشف 
        public int FinshPataiant(int id) 
        {
            var data= db.DailyDetection.Where(x => x.Id == id).FirstOrDefault();
            data.State = true;
            db.SaveChanges();
            return id;
        }
        #endregion
        #region جلب كل الكشوفات الخاصه بالدكتور
        public IEnumerable<DailyDetectionViewModel> GetAll(string id)
        {
            List<DailyDetectionViewModel> Patiant = new List<DailyDetectionViewModel>();
            //يتم الاختبار باليوم المطلوب الكشف فيه والدكتور الى تم الحجز عنده
            var data = db.DailyDetection.Where(d => d.DateAndTime.Date == DateTime.Now.Date && d.State==false&&d.DoctorId==db.Doctors.Where(x=>x.UserId==id).Select(x=>x.Id).FirstOrDefault());
            foreach (var item in data)
            {
                DailyDetectionViewModel obj = new DailyDetectionViewModel();
                obj.Id = item.Id;
                obj.PatientId = item.PatientId;
                obj.PatientName = db.Patients.Where(x => x.Id == item.PatientId).Select(x=>x.Name).FirstOrDefault();
                obj.DateAndTime = item.DateAndTime;
                Patiant.Add(obj);
            }
            return Patiant;
        }
        #endregion
        #region 
        public async Task<DoctorWorkVM> GetByID(int id)
        {
            var patiantId=db.DailyDetection.Where(x=>x.Id==id).Select(x=>x.PatientId).FirstOrDefault();
            //var user = await userManager.FindByIdAsync(db.Patients.Where(x => x.Id == patiantId).Select(x => x.UserId).FirstOrDefault());
            var patient = db.Patients.Where(x => x.Id == patiantId)
                                    .Select(x => new DoctorWorkVM
                                    { 
                                        DailyDetectionId=id,
                                        Id = x.Id,
                                        Name = x.Name,
                                        Address = x.Address,
                                        BirthDate = x.BirthDate,
                                        Phone = x.Phone,
                                        AnotherPhone=x.AnotherPhone,
                                        SSN = x.SSN,
                                        photo = x.photo,
                                        Gender = x.Gender,
                                       
                                    })
                                    .FirstOrDefault();
            return patient;
        }
        #endregion
        public DoctorWorkVM GetPatientByID(int id)
        {
            var patiantId = db.DailyDetection.Where(x => x.PatientId == id).Select(x => x.PatientId).FirstOrDefault();
            var patient = db.Patients.Where(x => x.Id == patiantId)
                                    .Select(x => new DoctorWorkVM
                                    {
                                        DailyDetectionId = id,
                                        Id = x.Id,
                                        Name = x.Name,
                                        Address = x.Address,
                                        BirthDate = x.BirthDate,
                                        Phone = x.Phone,
                                        SSN = x.SSN,
                                        photo = x.photo,
                                        Gender = x.Gender,

                                    })
                                    .FirstOrDefault();
            return patient;
        }
        
        
    }
}
