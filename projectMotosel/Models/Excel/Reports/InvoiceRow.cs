using MotoselProject.Models;
using projectMotosel.Models.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectMotosel.Models
{
    /* This is assumed to be a ROW in Invoice model*/
    public class InvoiceRow
    {
        [Key]
        public int InvoiceRowId { get; set; }

        public int SaleRowId { get; set; }

        [ForeignKey("SaleRowId")]
        public virtual SaleRow SaleRow { get; set; }

        public string PONumber { get; set; }
    }
}