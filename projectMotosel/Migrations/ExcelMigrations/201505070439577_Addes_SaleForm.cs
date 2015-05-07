namespace projectMotosel.Migrations.ExcelMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addes_SaleForm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SaleForms",
                c => new
                    {
                        SaleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SaleId)
                .ForeignKey("dbo.Sales", t => t.SaleId)
                .Index(t => t.SaleId);
            
            AddForeignKey("dbo.SaleRows", "SaleId", "dbo.SaleForms", "SaleId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleRows", "SaleId", "dbo.SaleForms");
            DropForeignKey("dbo.SaleForms", "SaleId", "dbo.Sales");
            DropIndex("dbo.SaleForms", new[] { "SaleId" });
            DropTable("dbo.SaleForms");
        }
    }
}
