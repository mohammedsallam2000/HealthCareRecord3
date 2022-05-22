using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class SurgeryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        public String Name { get; set; }
        public bool State { get; set; }
        [Required(ErrorMessage = "Price Is Required")]
        public decimal Price { get; set; }
        public bool Delete { get; set; }
    }
}
