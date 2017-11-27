namespace InventoryDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removingProductPerInvoiceEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductPerInvoices", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.ProductPerInvoices", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductPerInvoices", new[] { "InvoiceId" });
            DropIndex("dbo.ProductPerInvoices", new[] { "ProductId" });
            DropTable("dbo.ProductPerInvoices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductPerInvoices",
                c => new
                    {
                        ProductXIvoiceId = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductXIvoiceId);
            
            CreateIndex("dbo.ProductPerInvoices", "ProductId");
            CreateIndex("dbo.ProductPerInvoices", "InvoiceId");
            AddForeignKey("dbo.ProductPerInvoices", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.ProductPerInvoices", "InvoiceId", "dbo.Invoices", "InvoiceId", cascadeDelete: true);
        }
    }
}
