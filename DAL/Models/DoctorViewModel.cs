using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Index(nameof(SSN), IsUnique = true)]
    public class DoctorViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter doctor name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "SSN is Required")]
        [MinLength(14, ErrorMessage = "SSN Must Be 14 Number This is less than 14")]
        [MaxLength(14, ErrorMessage = "SSN Must Be 14 Number This is more than 14")]
        [Remote(action: "SSNUssed", controller: "Doctor")]

       
        public string SSN { get; set; }
       
        [Required(ErrorMessage = "Phone Is Required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Gender Is Required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Enter Your BirthDate")]
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string Degree { get; set; }
        [Required(ErrorMessage = "Enter Your Date of WorkStarts")]
        public DateTime? WorkStartTime { get; set; }
        public bool IsActive { get; set; }
        public int? DepartmentId { get; set; }

        [Required(ErrorMessage = "Department Name is Required")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Shift is Required")]
        public int? ShiftId { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid EMail")]
        [Remote(action: "VerifyEmail", controller: "Users")]
        public string Email { get; set; }

        public string UserId { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [MinLength(6, ErrorMessage = "Min Len 6 Characters")]
        public string Password { get; set; }

        public IFormFile PhotoUrl { get; set; }
        public string Photo { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Whatsapp { get; set; }
    }
}
