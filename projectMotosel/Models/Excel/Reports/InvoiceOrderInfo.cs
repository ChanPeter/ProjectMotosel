﻿using MotoselProject.Models;
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
        [Key, Column(Order = 0)]
        public int InvoiceOrderInfoId { get; set; }
        [Key, Column(Order = 1)]
        public string SKU { get; set; }
        public int InvoiceId { get; set; }

        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }

        [ForeignKey("SKU")]
        public virtual Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string PONumber { get; set; }
    }
}