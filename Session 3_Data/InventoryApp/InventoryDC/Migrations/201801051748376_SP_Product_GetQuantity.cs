namespace InventoryDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SP_Product_GetQuantity : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("SP_Product_GetQuantity",
                p => new {
                    productId = p.Int(),
                }, body: @"SELECT ProductId, Quantity FROM Products
                           WHERE ProductId = @productId");
        }
        
        public override void Down()
        {
            DropStoredProcedure("SP_Product_GetQuantity");
        }
    }
}
