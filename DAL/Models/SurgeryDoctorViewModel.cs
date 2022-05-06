using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class SurgeryDoctorViewModel
    {
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string SurgeryName { get; set; }

        public DateTime DateAndTime { get; set; }
        public int PatientLabId { get; set; }
    }
}
