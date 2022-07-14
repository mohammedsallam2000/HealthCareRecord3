using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.StatisticServices
{
   
    public  class StatisticServices : IStatisticServices
    {
        private readonly AplicationDbContext db;
        public StatisticServices(AplicationDbContext db)
        {
            this.db = db;
        }


        public int NumberOfDoctors()
        {
           return db.Doctors.Count();

        }
        public int NumberOfDepartments()
        {
            return db.Departments.Count();

        }

        public int NumberOfPatient()
        {
            return db.Patients.Count();

        }
        public int NumberOfNurses()
        {
            return db.Nurses.Count();

        }

        public int NumberOfRooms()
        {
            return db.Rooms.Count();

        }
        public int NumberOfEmptyRooms()
        {
            return db.Rooms.Where(x => x.State == false).Count();
        }

        public List<int> NumberOfAppointments()
        {
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(-7);
            var numDays = (int)((startDate - endDate).TotalDays);
            List<DateTime> myDates = Enumerable.Range(0, numDays)
                .Select(x => endDate.AddDays(x))
                .ToList();
            myDates.Add(startDate);
            List<int> obj = new List<int>();
            foreach (var item in myDates)
            {
                var count = db.DailyDetection.Where(x => x.DateAndTime == item).Count();
                obj.Add(count);
            }
            return obj;
        }
    }
}
