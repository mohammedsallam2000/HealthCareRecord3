using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class RoomVM
    {
        public int Id { get; set; }

        public int Floor { get; set; }
        public int Number { get; set; }
         public bool Delete { get; set; }
    }
}
