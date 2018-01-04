namespace InventoryDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SP_Invoice_Insert : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("SP_Invoice_Insert",
                p => new {
                    userId = p.Int(),
                    clientId = p.Int(),
                    fecha = p.DateTime()
                },
                body: @"INSERT INTO Invoices (clientId, InvoiceDate, userId)
                        VALUES (@clientId, @fecha, @userId)");
        }
        
        public override void Down()
        {
            DropStoredProcedure("SP_Invoice_Insert");
        }
    }
}
