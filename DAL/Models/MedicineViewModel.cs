using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class MedicineViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Price is Required")]

        public decimal Price { get; set; }
        [Required(ErrorMessage = "StartDate is Required")]
        [DataType(DataType.DateTime)]
        [CustomHireDate(ErrorMessage = "StartDate must be less than or equal to Today's Date")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "EndDate is Required")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        public int Count { get; set; }
        public class CustomHireDate : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                DateTime dateTime = Convert.ToDateTime(value);
                return dateTime <= DateTime.Now;
            }
        }
       
    }
}
