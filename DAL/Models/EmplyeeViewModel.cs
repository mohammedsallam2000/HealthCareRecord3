using Microsoft.AspNetCore.Http;
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
        public string SSN { get; set; }
        [Required(ErrorMessage = "BirthDate is Required")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Phone is Required")]
        public string Phone { get; set; }
        public string AnotherPhone { get; set; }
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
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Min Lenth 6")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Min Lenth 6")]
        [Compare("Password", ErrorMessage = "Not Matching")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public IFormFile PhotoUrl { get; set; }

    }
}
