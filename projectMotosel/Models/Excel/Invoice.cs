using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projectMotosel.Models
{
    public class Invoice
    {
        [Key]
        public int invoiceNo { get; set; }

        public DateTime invoiceDate { get; set; }

        public int soldToNo { get; set; }

        public int shipToNo { get; set; }
    }
}