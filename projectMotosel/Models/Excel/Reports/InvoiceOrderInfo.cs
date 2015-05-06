using MotoselProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectMotosel.Models
{
    /* This is assumed to be a ROW in Invoice model*/
    public class InvoiceOrderInfo
    {
        [Key]
        public int InvoiceOrderInfoId { get; set; }
        public int InvoiceId { get; set; }

        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }

        [Key]
        public string SKU { get; set; }
        [ForeignKey("SKU")]
        public virtual Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string PONumber { get; set; }
    }
}