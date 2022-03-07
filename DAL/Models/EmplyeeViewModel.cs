using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class EmplyeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long SSN { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string AnotherPhone { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public DateTime WorkStartTime { get; set; }
        public string Photo { get; set; }
        public int? ShiftId { get; set; }
        public string UserId { get; set; }
    }
}
