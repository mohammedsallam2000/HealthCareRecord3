using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class Surgery
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public bool State { get; set; }
    }
}
