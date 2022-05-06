using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class PatientRoom
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        public int? RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }
        public int? NurseId { get; set; }
        [ForeignKey("NurseId")]
        public Nurse Nurse { get; set; }
        public int? DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        public bool State { get; set; }
        public bool Cancel { get; set; }
        public int? DailyDetectionId { get; set; }
        [ForeignKey("DailyDetectionId")]
        public DailyDetection DailyDetection { get; set; }
    }
}
