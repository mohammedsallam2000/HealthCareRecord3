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

        public int? LabId { get; set; }
        [ForeignKey("LabId")]
        public Lab Lab { get; set; }
        public int? RadiologyId { get; set; }
        [ForeignKey("RadiologyId")]
        public Radiology Radiology { get; set; }
        public int? SurgeryId { get; set; }
        [ForeignKey("SurgeryId")]
        public Surgery Surgery { get; set; }

        public int? MedicineId { get; set; }
        [ForeignKey("MedicineId")]
        public Medicine Medicine { get; set; }

        public int? RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }

        public int? TreatmentId { get; set; }
        [ForeignKey("TreatmentId")]
        public Treatment Treatment { get; set; }
        public int? AdminId { get; set; }
        [ForeignKey("AdminId")]
        public Admin Admin { get; set; }
    }
}
