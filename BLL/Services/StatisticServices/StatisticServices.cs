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
    }
}
