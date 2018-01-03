namespace InventoryDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SP_Invoices_Select_By_Date : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("SP_Invoices_Select_By_Date",
                p => new {
                    desde = p.DateTime(),
                    hasta = p.DateTime()
                }
                , @"SELECT I.InvoiceId, i.InvoiceDate , c.ClientName + ' ' +c.Lastname AS ClientName, u.UserName
                    FROM Invoices i
                    JOIN Clients c ON c.ClientId = i.ClientId
                    JOIN Users u ON u.UserId = i.UserId
                    WHERE I.InvoiceDate BETWEEN @desde AND @hasta");

            CreateStoredProcedure("SP_Select_Invoices",
               
                @"SELECT I.InvoiceId, i.InvoiceDate , c.ClientName + ' ' +c.Lastname AS ClientName, u.UserName
                    FROM Invoices i
                    JOIN Clients c ON c.ClientId = i.ClientId
                    JOIN Users u ON u.UserId = i.UserId");

        }
        
        public override void Down()
        {
            DropStoredProcedure("SP_Invoices_Select_By_Date");
            DropStoredProcedure("SP_Select_Invoices");
        }
    }
}
