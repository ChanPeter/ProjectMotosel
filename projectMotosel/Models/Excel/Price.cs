﻿using MotoselProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectMotosel.Models
{
    public class Price
    {
        [Key]
        public string ProductId { get; set; }
        [Key]
        public int CustId { get; set; }

        public double PriceValue { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [ForeignKey("CustId")]
        public virtual Customer Customer { get; set; }
    }
}