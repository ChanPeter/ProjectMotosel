namespace projectMotosel.Migrations.ExcelMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changed_stuff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SaleForms", "SaleId", "dbo.Sales");
            DropForeignKey("dbo.SaleRows", "SaleId", "dbo.SaleForms");
            DropIndex("dbo.SaleForms", new[] { "SaleId" });
            DropTable("dbo.SaleForms");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SaleForms",
                c => new
                    {
                        SaleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SaleId);
            
            CreateIndex("dbo.SaleForms", "SaleId");
            AddForeignKey("dbo.SaleRows", "SaleId", "dbo.SaleForms", "SaleId", cascadeDelete: true);
            AddForeignKey("dbo.SaleForms", "SaleId", "dbo.Sales", "SaleId");
        }
    }
}
