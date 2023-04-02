using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.vacation
{
    public class VacationTypeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Vacation Name")]
        public string VacationName { get; set; } = string.Empty;
        [Display(Name = "Vacation Color")]

        public string Background { get; set; } = string.Empty;
        [Display(Name = "Number Of Days")]

        public int NumberDays { get; set; }
    }
}
