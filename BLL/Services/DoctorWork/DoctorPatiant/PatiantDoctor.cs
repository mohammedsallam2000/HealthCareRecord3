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
        public IEnumerable<DailyDetectionViewModel> GetAll()
        {
            List<DailyDetectionViewModel> Patiant = new List<DailyDetectionViewModel>();
            var data = db.DailyDetection.Where(d => d.DateAndTime.Date == DateTime.Now.Date);
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
    }
}
