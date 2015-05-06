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
        public int DeliveryId { get; set; }
        [Required]
        public int EmpId { get; set; }

        [ForeignKey("EmpId")]
        public virtual Employee Employee { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<DeliveryList> DeliveryLists { get; set; }

    }
}