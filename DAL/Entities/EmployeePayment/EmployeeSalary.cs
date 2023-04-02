using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entities.EmployeePayment
{
    public class EmployeeSalary
    {
        public int Id { get; set; }
        public DateTime date { get; set;}
        string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual IdentityUser User { get; set; }
        public double Salarey { get; set; }
        public double shiftCount { get; set; }
        public double TotalPayment { get; set; }
        public double IncreaseValue { get; set; }
        public double DecreaseSalary { get; set; }
        public bool TakeMoney { get; set; }
        





    }
}
