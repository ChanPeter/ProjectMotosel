using MotoselProject.Models;
using projectMotosel.Models.Excel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace projectMotosel.Models
{
    public class ExcelContext : DbContext
    {
        public ExcelContext() : base("DefaultConnection") { }

        public DbSet<Customer>          Customers       { get; set; }
        public DbSet<Employee>          Employees       { get; set; }
        public DbSet<Price>             Prices          { get; set; }
        public DbSet<Product>           Products        { get; set; }
        public DbSet<Sale>              Sales           { get; set; }
        public DbSet<SaleRow>           SaleRows        { get; set; }
        public DbSet<Invoice>           Invoices        { get; set; }
        public DbSet<InvoiceRow>        InvoiceRows     { get; set; }
        public DbSet<PickUpOrder>       PickUpOrders    { get; set; }
        public DbSet<PickUpOrderInfo>   PickUpOrderRow  { get; set; }

    }
}