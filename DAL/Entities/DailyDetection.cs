using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class DailyDetection
    {
        public int Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public bool State { get; set; }
        public int? PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        public int? NurseId { get; set; }
        [ForeignKey("NurseId")]
        public Nurse Nurse { get; set; }
        public int? DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        public int? EmplyeeId { get; set; }
        [ForeignKey("EmplyeeId")]
        public Emplyee Emplyee { get; set; }
        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public int? AdminId { get; set; }
        [ForeignKey("AdminId")]
        public Admin Admin { get; set; }
    }
}
