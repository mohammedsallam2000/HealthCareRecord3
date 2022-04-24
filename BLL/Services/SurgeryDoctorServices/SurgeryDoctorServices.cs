using DAL.Database;
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
                if (item.State == false)
                {
                    SurgeryDoctorViewModel objVM = new SurgeryDoctorViewModel();
                    objVM.DoctorName = context.Doctors.Where(x => x.Id == item.DoctorId).Select(x => x.Name).FirstOrDefault();
                    objVM.PatientName = context.Patients.Where(x => x.Id == item.PatientId).Select(x => x.Name).FirstOrDefault();
                    objVM.SurgeryName = context.Surgery.Where(x => x.Id == item.SurgeryId).Select(x => x.Name).FirstOrDefault();
                    objVM.DateAndTime = item.Time;
                    //objVM.RoomId = context.Rooms.Where(x => x.Id == item.RoomId).Select(x => x.Id).FirstOrDefault();
                    obj.Add(objVM);
                }
            }
            return obj;
        }
    }
}
