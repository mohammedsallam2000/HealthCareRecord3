using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class LabDoctorWorkViewModel
    {
        public int Id { get; set; }
        public int PatientLabId { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string AnalysisDoctorId { get; set; }
        public string LabName { get; set; }
        public string SSN { get; set; }
        public string Address { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string AnotherPhone { get; set; }
        [Required(ErrorMessage = "Document Required !")]
        public IFormFile DocumentUrl { get; set; }
        public string Document { get; set; }
        [Required(ErrorMessage = "Photo Required !")]
        public IFormFile PhotoUrl { get; set; }
        public string Photo { get; set; }
        public int DailyDetectionId { get; set; }
    }
}
