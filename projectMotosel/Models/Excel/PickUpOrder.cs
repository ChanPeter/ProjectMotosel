using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projectMotosel.Models
{
    public class PickUpOrder
    {
        [Key]
        public string orderNo { get; set; }

        public DateTime Date { get; set; }

        public int soldToNo { get; set; }

        public int shipToNo { get; set; }
    }
}