namespace projectMotosel.Migrations.ExcelMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Create : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeliveryLists", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.DeliveryLists", "DeliveryId", "dbo.Deliveries");
            DropForeignKey("dbo.DeliveryLists", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.DeliveryLists", "SKU", "dbo.Products");
            DropForeignKey("dbo.Deliveries", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.GoodsReceivedNotes", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.GoodsReceivedNotes", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.GRNOrderInfoes", "GoodsReceivedNoteId", "dbo.GoodsReceivedNotes");
            DropForeignKey("dbo.GRNOrderInfoes", "SKU", "dbo.Products");
            DropForeignKey("dbo.InvoiceOrderInfoes", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "ShipToId", "dbo.Customers");
            DropForeignKey("dbo.Invoices", "SoldToId", "dbo.Customers");
            DropForeignKey("dbo.InvoiceOrderInfoes", "SKU", "dbo.Products");
            DropForeignKey("dbo.PickUpOrderInfoes", "PickupOrderId", "dbo.PickUpOrders");
            DropForeignKey("dbo.PickUpOrders", "ShipToId", "dbo.Customers");
            DropForeignKey("dbo.PickUpOrders", "SoldToId", "dbo.Customers");
            DropIndex("dbo.Deliveries", new[] { "EmployeeId" });
            DropIndex("dbo.DeliveryLists", new[] { "CustomerId" });
            DropIndex("dbo.DeliveryLists", new[] { "EmployeeId" });
            DropIndex("dbo.DeliveryLists", new[] { "DeliveryId" });
            DropIndex("dbo.DeliveryLists", new[] { "SKU" });
            DropIndex("dbo.GoodsReceivedNotes", new[] { "CustomerId" });
            DropIndex("dbo.GoodsReceivedNotes", new[] { "EmployeeId" });
            DropIndex("dbo.GRNOrderInfoes", new[] { "SKU" });
            DropIndex("dbo.GRNOrderInfoes", new[] { "GoodsReceivedNoteId" });
            DropIndex("dbo.InvoiceOrderInfoes", new[] { "SKU" });
            DropIndex("dbo.InvoiceOrderInfoes", new[] { "InvoiceId" });
            DropIndex("dbo.Invoices", new[] { "SoldToId" });
            DropIndex("dbo.Invoices", new[] { "ShipToId" });
            DropIndex("dbo.PickUpOrderInfoes", new[] { "PickupOrderId" });
            DropIndex("dbo.PickUpOrders", new[] { "SoldToId" });
            DropIndex("dbo.PickUpOrders", new[] { "ShipToId" });
            DropPrimaryKey("dbo.PickUpOrderInfoes");
            CreateTable(
                "dbo.InvoiceRows",
                c => new
                    {
                        InvoiceRowId = c.Int(nullable: false, identity: true),
                        SaleRowId = c.Int(nullable: false),
                        PONumber = c.String(),
                        Invoice_InvoiceId = c.Int(),
                    })
                .PrimaryKey(t => t.InvoiceRowId)
                .ForeignKey("dbo.SaleRows", t => t.SaleRowId, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceId)
                .Index(t => t.SaleRowId)
                .Index(t => t.Invoice_InvoiceId);
            
            CreateTable(
                "dbo.SaleRows",
                c => new
                    {
                        SaleRowId = c.Int(nullable: false, identity: true),
                        SaleId = c.Int(nullable: false),
                        SKU = c.String(nullable: false, maxLength: 128),
                        Quantity = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.SaleRowId)
                .ForeignKey("dbo.Products", t => t.SKU, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.SaleId, cascadeDelete: true)
                .Index(t => t.SaleId)
                .Index(t => t.SKU);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        SoldToId = c.Int(nullable: false),
                        ShipToId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        SaleDate = c.DateTime(nullable: false),
                        ShippingNo = c.String(),
                        PONumber = c.String(),
                    })
                .PrimaryKey(t => t.SaleId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.ShipToId, cascadeDelete: false)
                .ForeignKey("dbo.Customers", t => t.SoldToId, cascadeDelete: false)
                .Index(t => t.SoldToId)
                .Index(t => t.ShipToId)
                .Index(t => t.EmployeeId);
            
            AddColumn("dbo.Invoices", "SaleId", c => c.Int(nullable: false));
            AddColumn("dbo.PickUpOrderInfoes", "PickUpOrderRowId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.PickUpOrderInfoes", "SaleRowId", c => c.Int(nullable: false));
            AddColumn("dbo.PickUpOrders", "SaleId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PickUpOrderInfoes", "PickUpOrderRowId");
            CreateIndex("dbo.Invoices", "SaleId");
            CreateIndex("dbo.PickUpOrderInfoes", "SaleRowId");
            CreateIndex("dbo.PickUpOrders", "SaleId");
            AddForeignKey("dbo.Invoices", "SaleId", "dbo.Sales", "SaleId", cascadeDelete: true);
            AddForeignKey("dbo.PickUpOrderInfoes", "SaleRowId", "dbo.SaleRows", "SaleRowId", cascadeDelete: true);
            AddForeignKey("dbo.PickUpOrders", "SaleId", "dbo.Sales", "SaleId", cascadeDelete: true);
            DropColumn("dbo.Invoices", "InvoiceDate");
            DropColumn("dbo.Invoices", "SoldToId");
            DropColumn("dbo.Invoices", "ShipToId");
            DropColumn("dbo.PickUpOrderInfoes", "PickUpOrderInfoId");
            DropColumn("dbo.PickUpOrderInfoes", "SKU");
            DropColumn("dbo.PickUpOrderInfoes", "PickupOrderId");
            DropColumn("dbo.PickUpOrderInfoes", "Quantity");
            DropColumn("dbo.PickUpOrderInfoes", "PONumber");
            DropColumn("dbo.PickUpOrderInfoes", "Notes");
            DropColumn("dbo.PickUpOrders", "Date");
            DropColumn("dbo.PickUpOrders", "SoldToId");
            DropColumn("dbo.PickUpOrders", "ShipToId");
            DropTable("dbo.Deliveries");
            DropTable("dbo.DeliveryLists");
            DropTable("dbo.GoodsReceivedNotes");
            DropTable("dbo.GRNOrderInfoes");
            DropTable("dbo.InvoiceOrderInfoes");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => new { t.InvoiceOrderInfoId, t.SKU });
            
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
                .PrimaryKey(t => new { t.GRNOrderInfoId, t.SKU });
            
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
                .PrimaryKey(t => t.GoodsReceivedNoteId);
            
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
                .PrimaryKey(t => t.DeliveryListId);
            
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        DeliveryId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.DeliveryId);
            
            AddColumn("dbo.PickUpOrders", "ShipToId", c => c.Int(nullable: false));
            AddColumn("dbo.PickUpOrders", "SoldToId", c => c.Int(nullable: false));
            AddColumn("dbo.PickUpOrders", "Date", c => c.DateTime());
            AddColumn("dbo.PickUpOrderInfoes", "Notes", c => c.String());
            AddColumn("dbo.PickUpOrderInfoes", "PONumber", c => c.String());
            AddColumn("dbo.PickUpOrderInfoes", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.PickUpOrderInfoes", "PickupOrderId", c => c.String(maxLength: 128));
            AddColumn("dbo.PickUpOrderInfoes", "SKU", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.PickUpOrderInfoes", "PickUpOrderInfoId", c => c.Int(nullable: false));
            AddColumn("dbo.Invoices", "ShipToId", c => c.Int(nullable: false));
            AddColumn("dbo.Invoices", "SoldToId", c => c.Int(nullable: false));
            AddColumn("dbo.Invoices", "InvoiceDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.PickUpOrders", "SaleId", "dbo.Sales");
            DropForeignKey("dbo.PickUpOrderInfoes", "SaleRowId", "dbo.SaleRows");
            DropForeignKey("dbo.Invoices", "SaleId", "dbo.Sales");
            DropForeignKey("dbo.InvoiceRows", "Invoice_InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.InvoiceRows", "SaleRowId", "dbo.SaleRows");
            DropForeignKey("dbo.Sales", "SoldToId", "dbo.Customers");
            DropForeignKey("dbo.Sales", "ShipToId", "dbo.Customers");
            DropForeignKey("dbo.SaleRows", "SaleId", "dbo.Sales");
            DropForeignKey("dbo.Sales", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.SaleRows", "SKU", "dbo.Products");
            DropIndex("dbo.PickUpOrders", new[] { "SaleId" });
            DropIndex("dbo.PickUpOrderInfoes", new[] { "SaleRowId" });
            DropIndex("dbo.Invoices", new[] { "SaleId" });
            DropIndex("dbo.Sales", new[] { "EmployeeId" });
            DropIndex("dbo.Sales", new[] { "ShipToId" });
            DropIndex("dbo.Sales", new[] { "SoldToId" });
            DropIndex("dbo.SaleRows", new[] { "SKU" });
            DropIndex("dbo.SaleRows", new[] { "SaleId" });
            DropIndex("dbo.InvoiceRows", new[] { "Invoice_InvoiceId" });
            DropIndex("dbo.InvoiceRows", new[] { "SaleRowId" });
            DropPrimaryKey("dbo.PickUpOrderInfoes");
            DropColumn("dbo.PickUpOrders", "SaleId");
            DropColumn("dbo.PickUpOrderInfoes", "SaleRowId");
            DropColumn("dbo.PickUpOrderInfoes", "PickUpOrderRowId");
            DropColumn("dbo.Invoices", "SaleId");
            DropTable("dbo.Sales");
            DropTable("dbo.SaleRows");
            DropTable("dbo.InvoiceRows");
            AddPrimaryKey("dbo.PickUpOrderInfoes", new[] { "PickUpOrderInfoId", "SKU" });
            CreateIndex("dbo.PickUpOrders", "ShipToId");
            CreateIndex("dbo.PickUpOrders", "SoldToId");
            CreateIndex("dbo.PickUpOrderInfoes", "PickupOrderId");
            CreateIndex("dbo.Invoices", "ShipToId");
            CreateIndex("dbo.Invoices", "SoldToId");
            CreateIndex("dbo.InvoiceOrderInfoes", "InvoiceId");
            CreateIndex("dbo.InvoiceOrderInfoes", "SKU");
            CreateIndex("dbo.GRNOrderInfoes", "GoodsReceivedNoteId");
            CreateIndex("dbo.GRNOrderInfoes", "SKU");
            CreateIndex("dbo.GoodsReceivedNotes", "EmployeeId");
            CreateIndex("dbo.GoodsReceivedNotes", "CustomerId");
            CreateIndex("dbo.DeliveryLists", "SKU");
            CreateIndex("dbo.DeliveryLists", "DeliveryId");
            CreateIndex("dbo.DeliveryLists", "EmployeeId");
            CreateIndex("dbo.DeliveryLists", "CustomerId");
            CreateIndex("dbo.Deliveries", "EmployeeId");
            AddForeignKey("dbo.PickUpOrders", "SoldToId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.PickUpOrders", "ShipToId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.PickUpOrderInfoes", "PickupOrderId", "dbo.PickUpOrders", "PickUpOrderId");
            AddForeignKey("dbo.InvoiceOrderInfoes", "SKU", "dbo.Products", "SKU", cascadeDelete: true);
            AddForeignKey("dbo.Invoices", "SoldToId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.Invoices", "ShipToId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.InvoiceOrderInfoes", "InvoiceId", "dbo.Invoices", "InvoiceId", cascadeDelete: true);
            AddForeignKey("dbo.GRNOrderInfoes", "SKU", "dbo.Products", "SKU", cascadeDelete: true);
            AddForeignKey("dbo.GRNOrderInfoes", "GoodsReceivedNoteId", "dbo.GoodsReceivedNotes", "GoodsReceivedNoteId", cascadeDelete: true);
            AddForeignKey("dbo.GoodsReceivedNotes", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
            AddForeignKey("dbo.GoodsReceivedNotes", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.Deliveries", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
            AddForeignKey("dbo.DeliveryLists", "SKU", "dbo.Products", "SKU");
            AddForeignKey("dbo.DeliveryLists", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
            AddForeignKey("dbo.DeliveryLists", "DeliveryId", "dbo.Deliveries", "DeliveryId", cascadeDelete: true);
            AddForeignKey("dbo.DeliveryLists", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
    }
}
