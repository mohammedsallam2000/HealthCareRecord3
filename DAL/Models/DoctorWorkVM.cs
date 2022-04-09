using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class DoctorWorkVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public string SSN { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }
        public string Phone { get; set; }
        public string AnotherPhone { get; set; }
        public string photo { get; set; }
        //Medicine
        public string Notes { get; set; }
        public string MedicineName { get; set; }
        public string LabName { get; set; }
        public string RediologeyName { get; set; }


    }
}
