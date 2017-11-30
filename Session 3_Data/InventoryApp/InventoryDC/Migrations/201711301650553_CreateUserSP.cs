namespace InventoryDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUserSP : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("SP_User_Add",
               p => new {
                   UserName = p.String(),
                   Password = p.String(),
                   IsAdmin = p.Boolean(),
               }, @"INSERT INTO Users (UserName, Password, IsAdmin)
                    VALUES(@UserName, @Password, @IsAdmin)");
        }
        
        public override void Down()
        {
            DropStoredProcedure("SP_User_Add");
        }
    }
}
