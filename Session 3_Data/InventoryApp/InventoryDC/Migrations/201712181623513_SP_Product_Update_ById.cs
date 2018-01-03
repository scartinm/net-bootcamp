namespace InventoryDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SP_Product_Update_ById : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("SP_Product_Update_ById",
                p => new {
                    productId = p.Int(),
                    quantity = p.Int(),
                }
                ,@"UPDATE Products
                   SET Quantity = @quantity
                   WHERE ProductId = @productId");
        }
        
        public override void Down()
        {
            DropStoredProcedure("SP_Product_Update_ById");
        }
    }
}
