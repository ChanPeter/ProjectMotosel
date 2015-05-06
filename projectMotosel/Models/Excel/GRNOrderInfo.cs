using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projectMotosel.Models
{
    public class GRNOrderInfo
    {
        [Key]
        public int GRNOrderInfoId { get; set; }
        [Key]
        public string SKU { get; set; }

        [Required]
        public int Quantity { get; set; }


        //TODO: Shouldn't this be a reference to Customer.poBox?
        public int PONumber { get; set; }
    }
}