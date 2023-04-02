using DAL.Entities.vacation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.vacation
{
    public class RequestVacationViewModel
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string UserId { get; set; }

        public int VacationTypeId { get; set; }
        public VacationType VacationType { get; set; }= new VacationType();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Comment { get; set; }
        public bool Approved { get; set; }
        public DateTime? DataApproved { get; set; }

        public List<vacationPlan> vacationPlans { get; set; } = new List<vacationPlan>();
        public Userinfo userinfos { get; set; } = new Userinfo();

    }
     public class Userinfo
        {
        public string Name { get; set; }
        public string Department { get; set; }

    }
}
