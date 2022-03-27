using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DAL.Models
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Floor is Required")]

        public int Floor { get; set; }
        [Required(ErrorMessage = "Number is Required")]

        public int Number { get; set; }
    }
}
