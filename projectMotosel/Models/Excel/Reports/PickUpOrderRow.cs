using projectMotosel.Models.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectMotosel.Models
{
    public class PickUpOrderInfo
    {
        [Key]
        public int PickUpOrderRowId { get; set; }
        public int SaleRowId { get; set; }

        [ForeignKey("SaleRowId")]
        public virtual SaleRow SaleRow { get; set; }
    }
}