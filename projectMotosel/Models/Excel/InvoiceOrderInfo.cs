using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projectMotosel.Models
{
    /* This is assumed to be a ROW in Invoice model*/
    // TODO: Write 1-n relationship
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