using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class RoomVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Floor is Required")]
        public int Floor { get; set; }
        [Required(ErrorMessage = "Number is Required")]
        public int Number { get; set; }
         public bool Delete { get; set; }
    }
}
