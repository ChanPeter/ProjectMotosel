using MotoselProject.Models;
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
        [Key, Column(Order = 0)]
        public string ProductId { get; set; }
        [Key, Column(Order = 1)]
        public int CustomerId { get; set; }

        public decimal? PriceValue { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}