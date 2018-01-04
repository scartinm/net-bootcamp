namespace InventoryDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SP_Product_Get_Status_True : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("SP_Product_Get_Status_True",
                body:@"SELECT * FROM products
                        WHERE status = 1");
        }
        
        public override void Down()
        {
            DropStoredProcedure("SP_Product_Get_Status_True");
        }
    }
}
