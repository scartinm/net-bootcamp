namespace InventoryDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SP_Product_Add : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("SP_Product_Add",
                p => new {
                    Name = p.String(),
                    Price = p.Int(),
                    Quantity = p.Int(),
                    CategoryId = p.Int(),
                }
                ,@"INSERT INTO Products (Name, Price, Quantity, CategoryId)
                   VALUES (@Name, @Price, @Quantity, @CategoryId)");

            
        }
        
        public override void Down()
        {
            DropStoredProcedure("SP_Product_Add");
        }
    }
}
