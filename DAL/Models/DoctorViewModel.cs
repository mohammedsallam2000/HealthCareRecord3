using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter doctor name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter doctor ssn")]
        public long SSN { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string Degree { get; set; }
        public DateTime? WorkStartTime { get; set; }
        public string Photo { get; set; }
       
    }
}
