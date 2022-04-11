using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class SurgeryViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public bool State { get; set; }
        public decimal Price { get; set; }
        public bool Delete { get; set; }
    }
}
