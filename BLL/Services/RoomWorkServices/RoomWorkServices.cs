using DAL.Database;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.RoomWorkServices
{
   public class RoomWorkServices : IRoomWorkServices
    {
        private readonly AplicationDbContext context;

        public RoomWorkServices(AplicationDbContext context)
        {
            this.context = context;
        }

        public bool Cancel(int Id)
        {
            try
            {
                var Data = context.PatientRoom.Where(x => x.Id == Id).FirstOrDefault();
                Data.Cancel = true;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ConfirmOrder(int Id)
        {
            try
            {
                var Data = context.PatientRoom.Where(x => x.Id == Id).FirstOrDefault();
                var Data2 = context.Room.Where(x => x.Id == Data.RoomId).FirstOrDefault();
                Data2.State = true;
                Data.State = true;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<RoomWorkViewModel> GetAllOrders()
        {
           List< RoomWorkViewModel> obj = new List<RoomWorkViewModel>();
            foreach (var item in context.PatientRoom)
            {
                if (item.State == false && item.Cancel==false)
                {
                    RoomWorkViewModel objVM = new RoomWorkViewModel();
                    var DoctorId = context.DailyDetection.Where(x => x.Id == item.DailyDetectionId).Select(x => x.DoctorId).FirstOrDefault();
                    objVM.DoctorName = context.Doctors.Where(x => x.Id == DoctorId).Select(x => x.Name).FirstOrDefault();
                    var PatientId = context.DailyDetection.Where(x => x.Id == item.DailyDetectionId).Select(x => x.PatientId).FirstOrDefault();

                    objVM.PatientName=context.Patients.Where(x => x.Id == PatientId).Select(x => x.Name).FirstOrDefault();
                    objVM.Floor=context.Rooms.Where(x=>x.Id==item.RoomId).Select(x => x.Floor).FirstOrDefault();
                    objVM.RoomNumber = context.Rooms.Where(x => x.Id == item.RoomId).Select(x => x.Number).FirstOrDefault();
                    objVM.DateAndTime = item.StartTime;
                    objVM.PatientRoomId = item.Id;
                    obj.Add(objVM);
                }
            }
            return obj;
        }
    }
}
