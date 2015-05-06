using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projectMotosel.Models
{
    public class Customer
    {
        [Key]
        public int custNo { get; set; }

        public string custName { get; set; }

        public string custStreet { get; set; }

        public string custCity { get; set; }

        public string custProv { get; set; }

        public string custPostCode { get; set; }

        public string custPhone { get; set; }
    }
}