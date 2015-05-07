using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectMotosel.Models.Excel
{
    public class Sale
    {
        public Sale()
        {
            SaleRows = new List<SaleRow>();
        }
        [Key]
        public int SaleId { get; set; }
        public int SoldToId { get; set; }
        public int ShipToId { get; set; }
        [Required]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
        [ForeignKey("SoldToId")]
        public virtual Customer SoldToCustomer { get; set; }
        [ForeignKey("ShipToId")]
        public virtual Customer ShipToCustomer { get; set; }

        [Required]
        public DateTime SaleDate { get; set; }

        public string ShippingNo { get; set; }
        public string PONumber { get; set; }

        public virtual ICollection<SaleRow> SaleRows { get; set; }
    }
}