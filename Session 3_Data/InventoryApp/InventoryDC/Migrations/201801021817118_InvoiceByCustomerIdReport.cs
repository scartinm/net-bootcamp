namespace InventoryDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceByCustomerIdReport : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("SP_Invoices_Select_ByCustomerId",
                p => new {
                    CustomerId = p.Int()
                },
                body:
                @"SELECT I.InvoiceId, i.InvoiceDate, c.ClientName + ' ' + c.Lastname AS ClientName, u.UserName
                    FROM Invoices i
                    JOIN Clients c ON c.ClientId = i.ClientId
                    JOIN Users u ON u.UserId = i.UserId
                    WHERE i.ClientId = @CustomerId");

            CreateStoredProcedure(
                "SP_Invoices_Get_GrandTotal_ByCustomerId",
                p => new
                {
                    CustomerId = p.Int()
                },
                body:
                @"SELECT SUM(pi.Quantity * p.Price) AS Total
				FROM Invoices i
				JOIN ProductPerInvoices pi ON pi.InvoiceId = i.InvoiceId
				JOIN Products p ON p.ProductId = pi.ProductId
				WHERE i.clientId = @CustomerId "
            );

            CreateStoredProcedure(
                "SP_Invoices_GetTop3Products_ByCustomerId",
                p => new
                {
                    CustomerId = p.Int()
                },
                body:
                @"SELECT top 3 pi.ProductId, p.Name, SUM(pi.Quantity) AS Total_Quantity, c.CategoryName
				FROM ProductPerInvoices pi
				JOIN Invoices i on i.InvoiceId = pi.InvoiceId
				JOIN Products p on p.ProductId = pi.ProductId
				JOIN Categories c on p.CategoryId = c.CategoryId
				WHERE i.ClientId = @CustomerId
				GROUP BY pi.ProductId, p.Name, c.CategoryName
				ORDER BY Total_Quantity DESC"
            );

            CreateStoredProcedure(
                "SP_Invoices_AverageSpentOnInvoices_ByCustomer",
                p => new
                {
                    CustomerId = p.Int()
                },
                body:
                @"SELECT AVG(TOTAL) AS Average
				FROM
				(
					SELECT c.ClientName +' ' +c.LastName as ClientName, pi.InvoiceId, SUM(pi.Quantity * p.Price) AS TOTAL
					FROM Invoices i
					JOIN ProductPerInvoices pi ON pi.InvoiceId = i.InvoiceId
					JOIN Clients c ON c.ClientId = i.ClientId
					JOIN Products p ON p.ProductId = pi.ProductId
					WHERE i.ClientId = @CustomerId 
					GROUP BY c.ClientName, c.LastName, pi.InvoiceId
				) AS InnerTable"
            );
        }
        
        public override void Down()
        {
            DropStoredProcedure("SP_Invoices_Select_ByCustomerId");
            DropStoredProcedure("SP_Invoices_Get_GrandTotal_ByCustomerId");
            DropStoredProcedure("SP_Invoices_GetTop3Products_ByCustomerId");
            DropStoredProcedure("SP_Invoices_AverageSpentOnInvoices_ByCustomer");
        }
    }
}
