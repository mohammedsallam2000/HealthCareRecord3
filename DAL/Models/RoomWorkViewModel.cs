using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class RoomWorkViewModel
    {
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public int Floor { get; set; }
        public int RoomNumber { get; set; }

        public DateTime DateAndTime { get; set; }
        public int PatientRoomId { get; set; }

    }
}
