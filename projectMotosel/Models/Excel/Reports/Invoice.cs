using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectMotosel.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        public DateTime InvoiceDate { get; set; }

        public int SoldToId { get; set; }

        public int ShipToId { get; set; }

        [ForeignKey("SoldToId")]
        public virtual Customer SoldToCustomer { get; set; }
        [ForeignKey("ShipToId")]
        public virtual Customer ShipToCustomer { get; set; }

        public virtual ICollection<InvoiceOrderInfo> InvoiceOrderInfos { get; set; }
    }
}