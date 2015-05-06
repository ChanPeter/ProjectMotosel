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
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Prov { get; set; }

        public string PostCode { get; set; }

        public string Phone { get; set; }
    }
}