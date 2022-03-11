using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "This Field Required")]
        [MinLength(6, ErrorMessage = "Min Len 6 Characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This Field Required")]
        [MinLength(6, ErrorMessage = "Min Len 6 Characters")]
        [Compare("Password", ErrorMessage = "Password Not Match")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
