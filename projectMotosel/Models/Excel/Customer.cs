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
        public int CustId { get; set; }

        [Required]
        public string CustName { get; set; }

        public string CustStreet { get; set; }

        public string CustCity { get; set; }

        public string CustProv { get; set; }

        public string CustPostCode { get; set; }

        public string CustPhone { get; set; }
    }
}