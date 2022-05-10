using DAL.Database;
using DAL.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.SurgeryDoctorServices
{
    public class SurgeryDoctorServices : ISurgeryDoctorServices
    {
        private readonly AplicationDbContext context;

        public SurgeryDoctorServices(AplicationDbContext context)
        {
            this.context = context;
        }

    

        public IEnumerable<SurgeryDoctorViewModel> GetAllOrders()
        {
            List<SurgeryDoctorViewModel> obj = new List<SurgeryDoctorViewModel>();
            foreach (var item in context.PatientSurgery)
            {
                if (item.State == false && item.Cancel==false)
                {
                    SurgeryDoctorViewModel objVM = new SurgeryDoctorViewModel();
                    var PatientId = context.DailyDetection.Where(x => x.Id == item.DailyDetectionId).Select(x => x.PatientId).FirstOrDefault();
                    objVM.PatientName = context.Patients.Where(x => x.Id == PatientId).Select(x => x.Name).FirstOrDefault();
                    var DoctorId = context.DailyDetection.Where(x => x.Id == item.DailyDetectionId).Select(x => x.DoctorId).FirstOrDefault();
                    objVM.DoctorName = context.Doctors.Where(x => x.Id == DoctorId).Select(x => x.Name).FirstOrDefault();
                    objVM.SurgeryName = context.Surgery.Where(x => x.Id == item.SurgeryId).Select(x => x.Name).FirstOrDefault();
                    objVM.OrderDateAndTime = item.OrderDateAndTime;
                    objVM.PatientLabId = item.Id;
                    obj.Add(objVM);
                }
            }
            return obj;
        }

        public PatientSurgeryViewModel ConfirmOrder(int id)
        {
            PatientSurgeryViewModel objVM = new PatientSurgeryViewModel();
            objVM.State = true;
            var OldData = context.PatientSurgery.FirstOrDefault(x => x.Id == id);
            OldData.DoneDateAndTime = DateTime.Now;
            OldData.State = objVM.State;
            context.SaveChanges();
            return objVM;
        }


        public bool Cancel(int Id)
        {
            try
            {
                var Data = context.PatientSurgery.Where(x => x.Id == Id).FirstOrDefault();
                Data.Cancel = true;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
