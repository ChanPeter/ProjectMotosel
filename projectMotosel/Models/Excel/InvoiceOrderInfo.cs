using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projectMotosel.Models
{
    public class InvoiceOrderInfo
    {
        [Key]
        public int InvoiceOrderInfoId { get; set; }

        [Key]
        public string SKU { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string PONumber { get; set; }
    }
}