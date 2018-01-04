namespace InventoryDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SP_Product_Disable : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("SP_Product_Disable",
               p => new {
                   productId = p.Int(),
               },
               body: @"UPDATE Products
                        SET status = 'false'
                        WHERE ProductId = @productId");
        }
        
        public override void Down()
        {
            DropStoredProcedure("SP_Product_Disable");
        }
    }
}
