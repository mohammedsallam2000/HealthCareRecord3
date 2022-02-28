using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class NurseViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Nurse name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter  Your SSN ")]
        [StringLength(14, ErrorMessage = "Length must be 14")]
        public long SSN { get; set; }
        [Required(ErrorMessage = "Enter Birthdate ")]

        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Enter Nurse phone")]

        public string Phone { get; set; }
        public string AnotherPhone { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage ="Enter Nerse Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter Date Start Worked At")]
        public DateTime WorkStartTime { get; set; }
        public string Photo { get; set; }
        public int? ShiftId { get; set; }
    }
}
