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
    public class NurseViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Nurse name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter  Your SSN ")]
        [StringLength(14, ErrorMessage = "Length must be 14")]
        [Remote(action: "SSNUssed", controller: "Nurse")]

        public string SSN { get; set; }

        [Required(ErrorMessage = "Enter Birthdate ")]
        [DataType(DataType.DateTime)]
        [CustomHireDate(ErrorMessage = "Enter Real Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Enter Nurse phone")]

        public string Phone { get; set; }
        public string AnotherPhone { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public DateTime WorkStartTime { get; set; }
        [Required(ErrorMessage = "Image is Reguired")]

        public IFormFile PhotoUrl { get; set; }
        public string Photo { get; set; }
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Shift is Reguired")]
        public int? ShiftId { get; set; }
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "You Must Enter Valid Email")]
        [Remote(action: "VerifyEmail", controller: "Users")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Min Lenth 6")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Conform Required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Min Lenth 6")]
        [Compare("Password", ErrorMessage = "Not Matching")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Whatsapp { get; set; }
        public class CustomHireDate : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                DateTime dateTime = Convert.ToDateTime(value);
                return dateTime.Year <= DateTime.Now.Year - 20;
            }
        }
    }
}
