using MotoselProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectMotosel.Models.Excel
{
    public class SaleRow
    {
        [Key]
        public int SaleRowId { get; set; }
        [Required]
        public int SaleId { get; set; }
        [Required]
        public string SKU { get; set; }

        [ForeignKey("SaleId")]
        public virtual Sale Sale { get; set; }
        [ForeignKey("SKU")]
        public virtual Product Product { get; set; }

        [Required] 
        public int Quantity { get; set; }

        public string Notes { get; set; }
    }
}