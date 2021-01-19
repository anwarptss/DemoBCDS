using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoBCDS.Models
{
    public class EmployeeModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage ="Employee Name Required")]
        public string EmpName { get; set; }

        [Range(25,35 ,ErrorMessage ="Employee Age Should in between 25 to 35")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Input age must be in numeric")]
        [Required]
        public string EmpAge { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Input EmpPhone must be in numeric")]
        public string EmpPhone { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage ="Password and Confirm Password must be same")]
        public string ConfirmPassword { get; set; }
    }
}