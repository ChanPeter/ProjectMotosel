using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MotoselProject.Models
{
    public class Product
    {
        // ProductId == SKU
        [Key]
        public string ProductId { get; set; }

        public string Description { get; set; }

        public string PKG { get; set; }

        public double EHC { get; set; }

        public bool SYN { get; set; }

        public int Volume { get; set; }
    }
}