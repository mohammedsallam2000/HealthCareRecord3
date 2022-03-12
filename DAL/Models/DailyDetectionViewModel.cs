using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class DailyDetectionViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Select Shift")]
        public DateTime DateAndTime { get; set; }
        public int? PatientId { get; set; }
      
        public int? NurseId { get; set; }

        [Required(ErrorMessage = "Select Doctor")]
        public int? DoctorId { get; set; }
       
        public int? EmplyeeId { get; set; }
       
        public int? LabId { get; set; }
     
        public int? RadiologyId { get; set; }
     
        public int? SurgeryId { get; set; }
      
        public int? MedicineId { get; set; }
      
        public int? RoomId { get; set; }
     
        public int? TreatmentId { get; set; }
      
        public int? AdminId { get; set; }
        [Required(ErrorMessage = "Select Department")]
        public int? DepartmentId { get; set; }
    }
}
