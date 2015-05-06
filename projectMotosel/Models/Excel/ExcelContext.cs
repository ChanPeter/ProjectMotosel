using MotoselProject.Models;
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

        public DbSet<Customer>          Customers           { get; set; }
        public DbSet<Delivery>          Deliveries          { get; set; }
        public DbSet<DeliveryList>      DeliveryLists       { get; set; }
        public DbSet<Employee>          Employees           { get; set; }
        public DbSet<GoodsReceivedNote> GoodsReceivedNotes  { get; set; }
        public DbSet<GRNOrderInfo>      GRNOrderInfos       { get; set; }
        public DbSet<Invoice>           Invoices            { get; set; }
        public DbSet<InvoiceOrderInfo>  InvoiceOrderInfos   { get; set; }
        public DbSet<PickUpOrder>       PickUpOrders        { get; set; }
        public DbSet<PickUpOrderInfo>   PickUpOrderInfos    { get; set; }
        public DbSet<Price>             Prices              { get; set; }
        public DbSet<Product>           Products            { get; set; }
    }
}