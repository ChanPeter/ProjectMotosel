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
        [Key, Column(Order = 0)]
        public int PickUpOrderInfoId { get; set; }

        [Key, Column(Order = 1)]
        public string SKU { get; set; }
        public int PickupOrderId { get; set; }

        [ForeignKey("PickupOrderId")]
        public virtual PickUpOrder PickUpOrder { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string PONumber { get; set; }

        public string Notes { get; set; }
    }
}