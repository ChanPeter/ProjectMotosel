using MotoselProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectMotosel.Models
{
    /* This is assumed to be a ROW inside the GoodsReceivedNote table */
    // TODO: Write 1-n relationship
    public class GRNOrderInfo
    {
        [Key]
        public int GRNOrderInfoId { get; set; }
        [Key]
        public string SKU { get; set; }

        [ForeignKey("SKU")]
        public virtual Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }

        public int PONumber { get; set; }
    }
}