using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.vacation
{
    public class RequestVacation
    {
        public int Id { get; set; }
        public DateTime RequestDate   { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual IdentityUser User { get; set; }
        public int VacationTypeId { get; set; }
        [ForeignKey("VacationTypeId")]
        public VacationType? VacationType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Comment { get; set; }
        public bool Approved { get; set; }

        public DateTime? DataApproved { get; set; }

        public List<vacationPlan> vacationPlans { get; set; } = new List<vacationPlan>();


    }
}
