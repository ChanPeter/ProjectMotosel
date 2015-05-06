using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projectMotosel.Models
{
    public class Employee
    {
        [Key]
        public string EmpId { get; set; }
        [Required]
        public string EmpFirstName { get; set; }
        [Required]
        public string EmpLastName { get; set; }
        [Required]
        public int CommRate { get; set; }
    }
}