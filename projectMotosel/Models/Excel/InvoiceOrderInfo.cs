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
        public int invoiceNo { get; set; }

        [Key]
        public string SKU { get; set; }

        public int quantity { get; set; }

        public string PONumber { get; set; }
    }
}