using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long SSN { get; set; }
        public string Phone { get; set; }
        public string AnotherPhone { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string Degree { get; set; }
        //public int? FkDeptId { get; set; }
        //public int UserId { get; set; }
        public DateTime? WorkStartTime { get; set; }
        //public int? FkShiftId { get; set; }
        public string Photo { get; set; }
        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        public int? ShiftId { get; set; }
        [ForeignKey("ShiftIdId")]
        public Shift Shift { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual IdentityUser User { get; set; }
    }
}
