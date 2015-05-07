using projectMotosel.Models.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectMotosel.Models
{
    /* This is assumed to be a ROW in PickUpOrder model*/
    // TODO: Write 1-n relationship
    public class PickUpOrder
    {
        [Key]
        public string PickUpOrderId { get; set; }

        public int SaleId { get; set; }

        [ForeignKey("SaleId")]
        public virtual Sale Sale { get; set; }
    }
}