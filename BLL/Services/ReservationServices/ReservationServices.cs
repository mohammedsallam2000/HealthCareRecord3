using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using BLL.Helper;
using DAL.Database;
using DAL.Entities;

namespace BLL.Services.ReservationServices
{
    public class ReservationServices : IReservationServices
    {
        private readonly AplicationDbContext db;

        //private readonly AplicationDbContext context = new AplicationDbContext();
        public ReservationServices(AplicationDbContext db)
        {
            this.db = db;
        }
        public bool Add(DailyDetectionViewModel detec)
        {           
                DailyDetection obj = new DailyDetection();
                obj.DoctorId = detec.DoctorId;
                obj.DateAndTime = DateTime.Now;
                obj.PatientId = 1;
                obj.DepartmentId = detec.DepartmentId;
               db.DailyDetection.Add(obj);
                db.SaveChanges();
                return true;

        }
    }
}
