namespace projectMotosel.Migrations.ExcelMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Street = c.String(),
                        City = c.String(),
                        Prov = c.String(),
                        PostCode = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        DeliveryId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.DeliveryId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.DeliveryLists",
                c => new
                    {
                        DeliveryListId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        DeliveryId = c.Int(nullable: false),
                        SKU = c.String(maxLength: 128),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeliveryListId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Deliveries", t => t.DeliveryId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.SKU)
                .Index(t => t.CustomerId)
                .Index(t => t.EmployeeId)
                .Index(t => t.DeliveryId)
                .Index(t => t.SKU);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        CommRate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        SKU = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        PKG = c.String(),
                        EHC = c.Double(nullable: false),
                        SYN = c.Boolean(nullable: false),
                        Volume = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SKU);
            
            CreateTable(
                "dbo.GoodsReceivedNotes",
                c => new
                    {
                        GoodsReceivedNoteId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.GoodsReceivedNoteId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.GRNOrderInfoes",
                c => new
                    {
                        GRNOrderInfoId = c.Int(nullable: false),
                        SKU = c.String(nullable: false, maxLength: 128),
                        GoodsReceivedNoteId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PONumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GRNOrderInfoId, t.SKU })
                .ForeignKey("dbo.GoodsReceivedNotes", t => t.GoodsReceivedNoteId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.SKU, cascadeDelete: true)
                .Index(t => t.SKU)
                .Index(t => t.GoodsReceivedNoteId);
            
            CreateTable(
                "dbo.InvoiceOrderInfoes",
                c => new
                    {
                        InvoiceOrderInfoId = c.Int(nullable: false),
                        SKU = c.String(nullable: false, maxLength: 128),
                        InvoiceId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PONumber = c.String(),
                    })
                .PrimaryKey(t => new { t.InvoiceOrderInfoId, t.SKU })
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.SKU, cascadeDelete: true)
                .Index(t => t.SKU)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        InvoiceDate = c.DateTime(nullable: false),
                        SoldToId = c.Int(nullable: false),
                        ShipToId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Customers", t => t.ShipToId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.SoldToId, cascadeDelete: true)
                .Index(t => t.SoldToId)
                .Index(t => t.ShipToId);
            
            CreateTable(
                "dbo.PickUpOrderInfoes",
                c => new
                    {
                        PickUpOrderInfoId = c.Int(nullable: false),
                        SKU = c.String(nullable: false, maxLength: 128),
                        PickupOrderId = c.String(maxLength: 128),
                        Quantity = c.Int(nullable: false),
                        PONumber = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => new { t.PickUpOrderInfoId, t.SKU })
                .ForeignKey("dbo.PickUpOrders", t => t.PickupOrderId)
                .Index(t => t.PickupOrderId);
            
            CreateTable(
                "dbo.PickUpOrders",
                c => new
                    {
                        PickUpOrderId = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(),
                        SoldToId = c.Int(nullable: false),
                        ShipToId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PickUpOrderId)
                .ForeignKey("dbo.Customers", t => t.ShipToId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.SoldToId, cascadeDelete: true)
                .Index(t => t.SoldToId)
                .Index(t => t.ShipToId);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        ProductId = c.String(nullable: false, maxLength: 128),
                        CustomerId = c.Int(nullable: false),
                        PriceValue = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.ProductId, t.CustomerId })
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prices", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Prices", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.PickUpOrders", "SoldToId", "dbo.Customers");
            DropForeignKey("dbo.PickUpOrders", "ShipToId", "dbo.Customers");
            DropForeignKey("dbo.PickUpOrderInfoes", "PickupOrderId", "dbo.PickUpOrders");
            DropForeignKey("dbo.InvoiceOrderInfoes", "SKU", "dbo.Products");
            DropForeignKey("dbo.Invoices", "SoldToId", "dbo.Customers");
            DropForeignKey("dbo.Invoices", "ShipToId", "dbo.Customers");
            DropForeignKey("dbo.InvoiceOrderInfoes", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.GRNOrderInfoes", "SKU", "dbo.Products");
            DropForeignKey("dbo.GRNOrderInfoes", "GoodsReceivedNoteId", "dbo.GoodsReceivedNotes");
            DropForeignKey("dbo.GoodsReceivedNotes", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.GoodsReceivedNotes", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Deliveries", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.DeliveryLists", "SKU", "dbo.Products");
            DropForeignKey("dbo.DeliveryLists", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.DeliveryLists", "DeliveryId", "dbo.Deliveries");
            DropForeignKey("dbo.DeliveryLists", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Prices", new[] { "CustomerId" });
            DropIndex("dbo.Prices", new[] { "ProductId" });
            DropIndex("dbo.PickUpOrders", new[] { "ShipToId" });
            DropIndex("dbo.PickUpOrders", new[] { "SoldToId" });
            DropIndex("dbo.PickUpOrderInfoes", new[] { "PickupOrderId" });
            DropIndex("dbo.Invoices", new[] { "ShipToId" });
            DropIndex("dbo.Invoices", new[] { "SoldToId" });
            DropIndex("dbo.InvoiceOrderInfoes", new[] { "InvoiceId" });
            DropIndex("dbo.InvoiceOrderInfoes", new[] { "SKU" });
            DropIndex("dbo.GRNOrderInfoes", new[] { "GoodsReceivedNoteId" });
            DropIndex("dbo.GRNOrderInfoes", new[] { "SKU" });
            DropIndex("dbo.GoodsReceivedNotes", new[] { "EmployeeId" });
            DropIndex("dbo.GoodsReceivedNotes", new[] { "CustomerId" });
            DropIndex("dbo.DeliveryLists", new[] { "SKU" });
            DropIndex("dbo.DeliveryLists", new[] { "DeliveryId" });
            DropIndex("dbo.DeliveryLists", new[] { "EmployeeId" });
            DropIndex("dbo.DeliveryLists", new[] { "CustomerId" });
            DropIndex("dbo.Deliveries", new[] { "EmployeeId" });
            DropTable("dbo.Prices");
            DropTable("dbo.PickUpOrders");
            DropTable("dbo.PickUpOrderInfoes");
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceOrderInfoes");
            DropTable("dbo.GRNOrderInfoes");
            DropTable("dbo.GoodsReceivedNotes");
            DropTable("dbo.Products");
            DropTable("dbo.Employees");
            DropTable("dbo.DeliveryLists");
            DropTable("dbo.Deliveries");
            DropTable("dbo.Customers");
        }
    }
}
