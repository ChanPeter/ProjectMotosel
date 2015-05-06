using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projectMotosel.Models
{
    public class Price
    {
        [Key]
        public string SKU { get; set; }
        [Key]
        public int custNo { get; set; }

        public double price { get; set; }
    }
}