using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class Treatment
    {
        public int Id { get; set; }
        public string Notes { get; set; }
        public bool State { get; set; }
        public bool Cancel { get; set; }
        public DateTime OrderDateAndTime { get; set; }
        public DateTime DoneDateAndTime { get; set; }
        public int? MedicineId { get; set; }
        [ForeignKey("MedicineId")]
        public Medicine Medicine { get; set; }
        public int? DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        public int? DailyDetectionId { get; set; }
        [ForeignKey("DailyDetectionId")]
        public DailyDetection DailyDetection { get; set; }
    }
}
