using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projectMotosel.Models
{
    public class PickUpOrderInfo
    {
        [Key]
        public int PickUpOrderInfoId { get; set; }

        [Key]
        public string SKU { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string PONumber { get; set; }

        public string Notes { get; set; }
    }
}