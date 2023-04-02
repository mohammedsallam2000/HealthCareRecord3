using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.vacation
{
    public class vacationPlan
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime VacationDate { get; set; }
        public int RequestVacationId { get; set; }
        [ForeignKey("RequestVacationId")]
        public RequestVacation? RequestVacation { get; set; }

    }
}
