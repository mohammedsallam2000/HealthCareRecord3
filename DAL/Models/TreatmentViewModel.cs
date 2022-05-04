using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TreatmentViewModel
    {
        public int Id { get; set; }
        public string Notes { get; set; }
        public string DocterName { get; set; }
        public bool State { get; set; }
        public bool Cancel { get; set; }
        public DateTime OrderDateAndTime { get; set; }
        public DateTime DoneDateAndTime { get; set; }
        public int? DailyDetectionId { get; set; }
    }
}
