namespace InventoryDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SP_UserValidation_Select : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("SP_UserValidation_Select",
                p => new
                {
                    UserName = p.String(),
                    Password = p.String()
                },
                @"SELECT UserId,IsAdmin FROM Users WHERE UserName = @UserName and Password = @Password"
                );
        }

        public override void Down()
        {
            ; DropStoredProcedure("SPUserValidation");
        }
    }
}
