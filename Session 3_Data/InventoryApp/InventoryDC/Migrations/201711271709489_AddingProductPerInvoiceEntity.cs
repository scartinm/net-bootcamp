namespace InventoryDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingProductPerInvoiceEntity : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.ProductXIvoiceId)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.InvoiceId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductPerInvoices", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductPerInvoices", "InvoiceId", "dbo.Invoices");
            DropIndex("dbo.ProductPerInvoices", new[] { "ProductId" });
            DropIndex("dbo.ProductPerInvoices", new[] { "InvoiceId" });
            DropTable("dbo.ProductPerInvoices");
        }
    }
}
