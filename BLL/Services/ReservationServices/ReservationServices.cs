using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using BLL.Helper;
using DAL.Database;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services.ReservationServices
{
    public class ReservationServices : IReservationServices
    {
        #region Fields
        private readonly AplicationDbContext db;
        private readonly UserManager<IdentityUser> userManager;
        #endregion

        #region Ctor
        public ReservationServices(AplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }
        #endregion

        #region Create An Appointment
        public string Add(DailyDetectionViewModel detec)
        {
            try
            {
                DailyDetection obj = new DailyDetection();
                obj.DoctorId = detec.DoctorId;
                obj.DateAndTime = detec.DateAndTime;
                obj.PatientId = detec.PatientId;
                obj.DepartmentId = detec.DepartmentId;
                db.DailyDetection.Add(obj);

                db.SaveChanges();
                var user = db.Doctors.Where(x => x.Id == detec.DoctorId).Select(x => x.UserId).FirstOrDefault();
                return user;
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion

        #region Get All Shifts
        public IEnumerable<ShiftViewModel> GetAllShifts()
        {
            List<ShiftViewModel> shf = new List<ShiftViewModel>();
            foreach (var item in db.Shifts)
            {
                ShiftViewModel obj = new ShiftViewModel();
                obj.Id = item.Id;
                obj.StartShift = item.StartShift;
                obj.EndShift = item.EndShift;
                shf.Add(obj);
            }
            return shf;
        }

        #endregion

    }
}
