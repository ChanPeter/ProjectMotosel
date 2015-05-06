﻿using MotoselProject.Models;
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
        public int DeliveryListId { get; set; }
        [Required]
        public int CustId { get; set; }
        [Required]
        public int EmpId { get; set; }
        public int DeliveryId { get; set; }
        public string SKU { get; set; }


        [ForeignKey("CustId")]
        public virtual Customer Customer { get; set; }
        [ForeignKey("EmpId")]
        public virtual Employee Employee { get; set; }
        [ForeignKey("SKU")]
        public virtual Product Product { get; set; }
        [ForeignKey("DeliveryId")]
        public virtual Delivery Delivery { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}