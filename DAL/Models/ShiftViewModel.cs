using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DAL.Models
{
    public class ShiftViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Start Shift Required")]
        public DateTime StartShift { get; set; }

        [Required(ErrorMessage = "End Shift Required")]
        public DateTime EndShift { get; set; }

    }
}
