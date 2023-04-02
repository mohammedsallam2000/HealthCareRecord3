using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.vacation
{
    public class UserVacationSum
    {
        
        public string Description { get; set; }
        public string Department { get; set; }
        [Required]
        public string DepartmentId { get; set; }


        public string userId { get; set; }
        [Required]
        public DateTime startdate { get; set; }
        [Required]
        public DateTime enddate { get; set; }
        
        public List<userVacationSums> userVacationSums { get; set; }
       

    
    
     }
    public class userVacationSums
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int TotalVacationDays { get; set; }
        public int TotalVacationDaysinTime { get; set; }

        public int? UserVacationDays { get; set; }

        public int RemingVacationDays { get; set; }
    }


}
