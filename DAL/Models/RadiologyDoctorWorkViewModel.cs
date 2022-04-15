using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class RadiologyDoctorWorkViewModel
    {
        public int Id { get; set; }
        public int PatientRadiologyId { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string RadiologyName { get; set; }
        public string SSN { get; set; }
        public string Address { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string AnotherPhone { get; set; }
        public string Photo { get; set; }
        public IFormFile PhotoUrl { get; set; }
        public IFormFile DocumentUrl { get; set; }
        public string Document { get; set; }
        public int DailyDetectionId { get; set; }
    }
}
