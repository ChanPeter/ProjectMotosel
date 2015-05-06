using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectMotosel.Models
{
    public class Delivery
    {
        [Key]
        public int deliveryNo { get; set; }

        [Required]
        public int empId { get; set; }
        [ForeignKey("empId")]
        public virtual Employee Employee { get; set; }

        public DateTime Date { get; set; }

    }
}