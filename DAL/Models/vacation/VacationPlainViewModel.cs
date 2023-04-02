using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.vacation;

namespace DAL.Models.vacation
{
    public class VacationPlainViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Vacation Date")]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? VacationDate { get; set; }
        public int RequestVacationId { get; set; }
        public RequestVacationViewModel? RequestVacationViewModel { get; set; }



    }
}
