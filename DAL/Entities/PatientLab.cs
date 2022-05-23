using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class PatientLab
    {
        public int Id { get; set; }
        public string Document { get; set; }
        public string Photo { get; set; }
        public bool State { get; set; }
        public bool Cancel { get; set; }
        public DateTime OrderDateAndTime { get; set; }
        public DateTime DoneDateAndTime { get; set; }
        public int? DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }       
        public int? LabId { get; set; }
        [ForeignKey("LabId")]
        public Lab Lab { get; set; }
        public int? DailyDetectionId { get; set; }
        [ForeignKey("DailyDetectionId")]
        public DailyDetection DailyDetection { get; set; }
    }

}
