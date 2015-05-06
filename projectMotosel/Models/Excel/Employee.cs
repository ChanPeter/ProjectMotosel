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
        public string empNo { get; set; }
        public string empFirstName { get; set; }
        public string empLastName { get; set; }
        public int commRate { get; set; }
    }
}