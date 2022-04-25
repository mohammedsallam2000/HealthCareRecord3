using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class PharmacistWorkViewModel
    {
        public int Id { get; set; }
        public int DailyDetectionId { get; set; }
        public int TreatmentId { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string MedicineName { get; set; }
        public string SSN { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public DateTime OrderDateAndTime { get; set; }
        public DateTime DoneDateAndTime { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string AnotherPhone { get; set; }
    }
}
