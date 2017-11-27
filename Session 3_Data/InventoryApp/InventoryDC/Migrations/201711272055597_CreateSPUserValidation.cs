namespace InventoryDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSPUserValidation : DbMigration
    {
        public override void Up()
        {
            AlterStoredProcedure("SPUserValidation",
                p => new
                {
                    UserName = p.String(),
                    Password = p.String()
                },
                @"SELECT IsAdmin FROM Users WHERE UserName = @UserName and Password = @Password"
                );
        }

        public override void Down()
        {
            ; DropStoredProcedure("SPUserValidation");
        }
    }
}
