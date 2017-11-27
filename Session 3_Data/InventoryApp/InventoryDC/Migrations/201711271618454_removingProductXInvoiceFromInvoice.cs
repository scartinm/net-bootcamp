namespace InventoryDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removingProductXInvoiceFromInvoice : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductPerInvoices", "ProductXIvoiceId", "dbo.Invoices");
            DropIndex("dbo.ProductPerInvoices", new[] { "ProductXIvoiceId" });
            DropPrimaryKey("dbo.ProductPerInvoices");
            AddColumn("dbo.ProductPerInvoices", "InvoiceId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductPerInvoices", "ProductXIvoiceId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ProductPerInvoices", "ProductXIvoiceId");
            CreateIndex("dbo.ProductPerInvoices", "InvoiceId");
            AddForeignKey("dbo.ProductPerInvoices", "InvoiceId", "dbo.Invoices", "InvoiceId", cascadeDelete: true);
            DropColumn("dbo.Invoices", "ProductXIvoiceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "ProductXIvoiceId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProductPerInvoices", "InvoiceId", "dbo.Invoices");
            DropIndex("dbo.ProductPerInvoices", new[] { "InvoiceId" });
            DropPrimaryKey("dbo.ProductPerInvoices");
            AlterColumn("dbo.ProductPerInvoices", "ProductXIvoiceId", c => c.Int(nullable: false));
            DropColumn("dbo.ProductPerInvoices", "InvoiceId");
            AddPrimaryKey("dbo.ProductPerInvoices", "ProductXIvoiceId");
            CreateIndex("dbo.ProductPerInvoices", "ProductXIvoiceId");
            AddForeignKey("dbo.ProductPerInvoices", "ProductXIvoiceId", "dbo.Invoices", "InvoiceId");
        }
    }
}
