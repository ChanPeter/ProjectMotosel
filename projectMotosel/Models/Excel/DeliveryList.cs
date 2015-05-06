using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectMotosel.Models
{
    public class DeliveryList
    {
        [Key]
        public int deliveryNo { get; set; }

        [Key]
        public int custNo { get; set; }
        [ForeignKey("custNo")]
        public virtual Customer Customer { get; set; }

        [Key]
        public string SKU { get; set; }

        public int quantity { get; set; }

        public int empNo { get; set; }
    }
}