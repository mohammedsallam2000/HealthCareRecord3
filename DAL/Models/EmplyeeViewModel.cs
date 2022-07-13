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
    public class EmplyeeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "SSN is Required")]
        [MinLength(14, ErrorMessage = "SSN Must Be 14 Number This is less than 14")]
        [MaxLength(14, ErrorMessage = "SSN Must Be 14 Number This is more than 14")]
        [Remote(action: "SSNUssed", controller: "Emplyee")]
        public string SSN { get; set; }
        [Required(ErrorMessage = "BirthDate is Required")]
        [DataType(DataType.DateTime)]
        [CustomHireDate(ErrorMessage = "Enter Real Birth Date")]
        public DateTime BirthDate { get; set; }
        [Phone(ErrorMessage = "Phone is Required")]
        [MinLength(11, ErrorMessage = "SSN Must Be 11 Number This is less than 11")]
        [MaxLength(11, ErrorMessage = "SSN Must Be 11 Number This is more than 11")]
        public string Phone { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
        public DateTime WorkStartTime { get; set; }
        public string Photo { get; set; }
        public bool IsActive { get; set; }
        public int? ShiftId { get; set; }
        public string UserId { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "You Must Enter Valid Email")]
        [Remote(action: "VerifyEmail", controller: "Users")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Min Lenth 6")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Min Lenth 6")]
        [Compare("Password", ErrorMessage = "Not Matching")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        //[RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        public IFormFile PhotoUrl { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Whatsapp { get; set; }
        public class CustomHireDate : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                DateTime dateTime = Convert.ToDateTime(value);
                return dateTime.Year <= DateTime.Now.Year - 15;
            }
        }
    }
}
