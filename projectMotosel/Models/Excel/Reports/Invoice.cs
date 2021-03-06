﻿using projectMotosel.Models.Excel;
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

        [Required]
        public int SaleId { get; set; }

        [ForeignKey("SaleId")]
        public virtual Sale Sale { get; set; }

        public virtual ICollection<InvoiceRow> InvoiceRows { get; set; }
    }
}