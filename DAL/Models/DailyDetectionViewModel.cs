using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class DailyDetectionViewModel
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "DateAndTime is Required")]
        [DataType(DataType.DateTime)]

        [CustomHireDate(ErrorMessage = "StartDate must greater than or equal to Today's Date")]

        public DateTime DateAndTime { get; set; }
        [Required(ErrorMessage ="Select patient ")]
        public int? PatientId { get; set; }
        public string PatientName { get; set; }
        [Required(ErrorMessage = "Doctor is Required")]
        public int? DoctorId { get; set; }
        [Required(ErrorMessage = "Department is Required")]
        public int? DepartmentId { get; set; }
        [Required(ErrorMessage = "Shift is Required")]
        public int? ShiftId { get; set; }
        public class CustomHireDate : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                DateTime dateTime = Convert.ToDateTime(value);
                return dateTime >= DateTime.Now;
            }
        }
    }
}
