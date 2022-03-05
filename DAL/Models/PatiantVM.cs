using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public  class PatiantVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public long SSN { get; set; }

        public string Address { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        public string AnotherPhone { get; set; }

        public string photo { get; set; }

        public DateTime LogInTime { get; set; }

        public DateTime LogOutTime { get; set; }

    }
}
