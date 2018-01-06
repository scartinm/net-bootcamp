namespace InventoryDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SP_Invoice_Select_Last_Added : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("SP_Invoice_Select_Last_Added",
                body: @"SELECT TOP 1 InvoiceId FROM Invoices ORDER BY InvoiceId desc");
        }
        
        public override void Down()
        {
            DropStoredProcedure("SP_Invoice_Select_Last_Added");
        }
    }
}
