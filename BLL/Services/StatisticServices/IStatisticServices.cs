using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.StatisticServices
{
  public  interface IStatisticServices
    {
         int NumberOfDoctors();
         int NumberOfDepartments();
         int NumberOfPatient();
         int NumberOfNurses();
         int NumberOfRooms();
         int NumberOfEmptyRooms();
        List<int> NumberOfAppointments();


    }
}
