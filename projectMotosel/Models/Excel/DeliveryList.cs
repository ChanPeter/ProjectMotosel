using MotoselProject.Models;
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

        [Key]
        public int CustId { get; set; }

        public int EmpId { get; set; }
        
        [Key]
        public string ProductId { get; set; }


        [ForeignKey("custId")]
        public virtual Customer Customer { get; set; }
        [ForeignKey("empId")]
        public virtual Employee Employee { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Required]
        public int quantity { get; set; }
    }
}