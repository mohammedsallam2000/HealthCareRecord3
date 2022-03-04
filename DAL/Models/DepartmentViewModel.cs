using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class DepartmentViewModel
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Enter department name")]
        public string Name { get; set; }
    }
}
