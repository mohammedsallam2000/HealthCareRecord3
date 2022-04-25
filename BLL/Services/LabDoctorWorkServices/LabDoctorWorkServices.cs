using BLL.Helper;
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

        public async Task<int> AddResult(LabDoctorWorkViewModel model)
        {
            var OldData = context.PatientLab.Where(x => x.Id == model.PatientLabId).Select(x => x).FirstOrDefault();
            if (model.PhotoUrl != null)
            {
                OldData.Photo = UploadFileHelper.SaveFile(model.PhotoUrl, "LabResults/Photos");
                
            }
            if(model.DocumentUrl != null)
            {
                OldData.Document = UploadFileHelper.SaveFile(model.DocumentUrl, "LabResults/Documents");
            }
            if (OldData.Photo != null || OldData.Document != null)
            {
                OldData.State = true;
                OldData.DoneDateAndTime = DateTime.Now;
                await context.SaveChangesAsync();
                return 1;
            }
            else
            {
                return 0;
            }
            
            
        }

        public IEnumerable<LabDoctorWorkViewModel> GetAllCompletedOrders()
        {
            var data = context.PatientLab.Select(x => x);
            List<LabDoctorWorkViewModel> obj = new List<LabDoctorWorkViewModel>();

            foreach (var item in data)
            {
                if (item.State == true)
                {
                    LabDoctorWorkViewModel objvm = new LabDoctorWorkViewModel();
                    var PatientId = context.DailyDetection.Where(x => x.Id == item.DailyDetectionId).Select(x => x.PatientId).FirstOrDefault();
                    objvm.PatientName = context.Patients.Where(x => x.Id == PatientId).Select(x => x.Name).FirstOrDefault();
                    var DoctorId = context.DailyDetection.Where(x => x.Id == item.DailyDetectionId).Select(x => x.DoctorId).FirstOrDefault();
                    objvm.DoctorName = context.Doctors.Where(x => x.Id == DoctorId).Select(x => x.Name).FirstOrDefault();
                    objvm.LabName = context.Lab.Where(x => x.Id == item.LabId).Select(x => x.Name).FirstOrDefault();
                    objvm.DateAndTime = item.DoneDateAndTime;
                    objvm.PatientLabId = item.Id;
                    obj.Add(objvm);
                }
            }
            return obj; throw new NotImplementedException();
        }

        public IEnumerable<LabDoctorWorkViewModel> GetAllOrders()
        {
            var data = context.PatientLab.Select(x => x);            
            List<LabDoctorWorkViewModel> obj = new List<LabDoctorWorkViewModel>();
            
            foreach (var item in data)
            {
                if (item.State == false)
                {
                    LabDoctorWorkViewModel objvm = new LabDoctorWorkViewModel();
                    var PatientId = context.DailyDetection.Where(x => x.Id == item.DailyDetectionId).Select(x => x.PatientId).FirstOrDefault();
                    objvm.PatientName = context.Patients.Where(x => x.Id == PatientId).Select(x => x.Name).FirstOrDefault();
                    var DoctorId = context.DailyDetection.Where(x => x.Id == item.DailyDetectionId).Select(x => x.DoctorId).FirstOrDefault();
                    objvm.DoctorName = context.Doctors.Where(x => x.Id == DoctorId).Select(x => x.Name).FirstOrDefault();
                    objvm.LabName = context.Lab.Where(x => x.Id == item.LabId).Select(x => x.Name).FirstOrDefault();
                    objvm.DateAndTime = item.OrderDateAndTime;
                    objvm.PatientLabId = item.Id;
                    obj.Add(objvm);
                }              
            }
            return obj;
        }

        public LabDoctorWorkViewModel GetByID(int id)
        {
            var patientLab = context.PatientLab.Where(x => x.Id == id).Select(x => x).FirstOrDefault();
            var DailyDetectionId = patientLab.DailyDetectionId;
            var PatientId = context.DailyDetection.Where(x => x.Id == DailyDetectionId).Select(x => x.PatientId).FirstOrDefault();
            var DoctorId = context.DailyDetection.Where(x => x.Id == DailyDetectionId).Select(x => x.DoctorId).FirstOrDefault();
            var DoctorName = context.Doctors.Where(x => x.Id == DoctorId).Select(c => c.Name).FirstOrDefault();
            var PatientData = context.Patients.Where(x => x.Id == PatientId).Select(x => x).FirstOrDefault();
            LabDoctorWorkViewModel obj = new LabDoctorWorkViewModel();
            obj.PatientName = PatientData.Name;
            obj.SSN = PatientData.SSN;
            obj.Address = PatientData.Address;
            obj.DoctorName = DoctorName;
            obj.PatientLabId = patientLab.Id;
            return obj;
        }
    }
}
