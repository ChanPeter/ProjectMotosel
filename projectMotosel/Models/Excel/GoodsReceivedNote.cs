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
        public int CustId { get; set; }
        [Required]
        public int EmpId { get; set; }

        [ForeignKey("CustId")]
        public virtual Customer Customer { get; set; }
        [ForeignKey("EmpId")]
        public virtual Employee Employee { get; set; }

        [Required]
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        
    }
}