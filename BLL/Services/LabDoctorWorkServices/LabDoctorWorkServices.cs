using DAL.Database;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.LabDoctorWorkServices
{
    public class LabDoctorWorkServices : ILabDoctorWorkServices
    {

        private readonly AplicationDbContext context;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public LabDoctorWorkServices(AplicationDbContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {

            this.context = context;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public IEnumerable<LabDoctorWorkViewModel> GetAllOrders()
        {
            var data = context.PatientLab.Select(x => x);
            
            List<LabDoctorWorkViewModel> obj = new List<LabDoctorWorkViewModel>();
            
            foreach (var item in data)
            {
                LabDoctorWorkViewModel objvm = new LabDoctorWorkViewModel();
                var PatientId = context.DailyDetection.Where(x => x.Id == item.DailyDetectionId).Select(x => x.PatientId).FirstOrDefault();
                objvm.PatientName = context.Patients.Where(x => x.Id == PatientId).Select(x=>x.Name).FirstOrDefault();
                var DoctorId = context.DailyDetection.Where(x => x.Id == item.DailyDetectionId).Select(x => x.DoctorId).FirstOrDefault();
                objvm.DoctorName = context.Doctors.Where(x => x.Id == DoctorId).Select(x => x.Name).FirstOrDefault();
                objvm.LabName = context.Lab.Where(x => x.Id == item.LabId).Select(x => x.Name).FirstOrDefault();
                objvm.DateAndTime = item.DateAndTime;
                objvm.PatientLabId = item.Id;
                obj.Add(objvm);
            }
            return obj;
        }

        public LabDoctorWorkViewModel GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
