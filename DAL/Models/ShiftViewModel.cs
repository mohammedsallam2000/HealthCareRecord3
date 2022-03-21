using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ShiftViewModel
    {
        public int Id { get; set; }
        public DateTime StartShift { get; set; }
        public DateTime EndShift { get; set; }

    }
}
