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

        #region Upload Result (reports) Of Analysis
        public async Task<int> AddResult(LabDoctorWorkViewModel model)
        {
            var OldData = context.PatientLab.Where(x => x.Id == model.PatientLabId).Select(x => x).FirstOrDefault();
            if (model.PhotoUrl != null)
            {
                OldData.Photo = UploadFileHelper.SaveFile(model.PhotoUrl, "LabResults/Photos");
            }
            if (model.DocumentUrl != null)
            {
                OldData.Document = UploadFileHelper.SaveFile(model.DocumentUrl, "LabResults/Documents");
            }
            if (OldData.Photo != null || OldData.Document != null)
            {
                OldData.State = true;
                OldData.DoneDateAndTime = DateTime.Now;
                OldData.DoctorId = context.Doctors.Where(x => x.UserId == model.AnalysisDoctorId).Select(x => x.Id).FirstOrDefault();
                await context.SaveChangesAsync();
                return 1;
            }
            else
            {
                return 0;
            }
        }
        #endregion


        #region Cancel Order 
        public bool Cancel(int Id)
        {
            try
            {
                var Data = context.PatientLab.Where(x => x.Id == Id).FirstOrDefault();
                Data.Cancel = true;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion


        #region Get All Completed Orders
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
            return obj;
        }
        #endregion

        #region Get All Orders (Waiting Page)
        public IEnumerable<LabDoctorWorkViewModel> GetAllOrders()
        {
            var data = context.PatientLab.Select(x => x);
            List<LabDoctorWorkViewModel> obj = new List<LabDoctorWorkViewModel>();
            foreach (var item in data)
            {
                if (item.State == false && item.Cancel == false)
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
        #endregion

        #region Get All Orders Which is canceled
        public IEnumerable<LabDoctorWorkViewModel> GetAllOrdersCanceled()
        {
            var data = context.PatientLab.Select(x => x);
            List<LabDoctorWorkViewModel> obj = new List<LabDoctorWorkViewModel>();

            foreach (var item in data)
            {
                if (item.Cancel == true)
                {
                    LabDoctorWorkViewModel objvm = new LabDoctorWorkViewModel();
                    var PatientId = context.DailyDetection.Where(x => x.Id == item.DailyDetectionId).Select(x => x.PatientId).FirstOrDefault();
                    objvm.PatientName = context.Patients.Where(x => x.Id == PatientId).Select(x => x.Name).FirstOrDefault();
                    var DoctorId = context.DailyDetection.Where(x => x.Id == item.DailyDetectionId).Select(x => x.DoctorId).FirstOrDefault();
                    objvm.DoctorName = context.Doctors.Where(x => x.Id == DoctorId).Select(x => x.Name).FirstOrDefault();
                    objvm.LabName = context.Lab.Where(x => x.Id == item.LabId).Select(x => x.Name).FirstOrDefault();
                    objvm.DateAndTime = item.DoneDateAndTime;
                    objvm.PatientLabId = item.Id;
                    objvm.DateAndTime = item.OrderDateAndTime;
                    obj.Add(objvm);
                }
            }
            return obj;
        }

        #endregion


        #region Get Patient Data And Doctor who order
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
            obj.Phone = PatientData.Phone;
            return obj;
        }

        #endregion


        #region Return Canceled order
        public bool NotCancel(int id)
        {
            try
            {
                var Data = context.PatientLab.Where(x => x.Id == id).FirstOrDefault();
                Data.Cancel = false;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}
