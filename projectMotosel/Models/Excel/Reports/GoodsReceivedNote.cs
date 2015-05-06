using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectMotosel.Models
{
    public class GoodsReceivedNote
    {
        [Key]
        public int GoodsReceivedNoteId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int EmployeeId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [Required]
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<GRNOrderInfo> GRNOrderInfos { get; set; }
        
    }
}