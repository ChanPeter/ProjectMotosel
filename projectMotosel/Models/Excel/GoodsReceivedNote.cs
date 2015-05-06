using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projectMotosel.Models
{
    public class GoodsReceivedNote
    {
        [Key]
        public int GRNNo { get; set; }
        public DateTime MyProperty { get; set; }
        public int custNo { get; set; }
        public string notes { get; set; }
        public int empNo { get; set; }
    }
}