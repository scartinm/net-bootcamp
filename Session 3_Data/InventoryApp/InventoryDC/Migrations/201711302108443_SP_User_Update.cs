namespace InventoryDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SP_User_Update : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("SP_User_Update",
                p => new {
                    UserId = p.Int(),
                    UserName = p.String(),
                    Password = p.String(),
                    IsAdmin = p.Boolean(),
                },"");
        }
        
        public override void Down()
        {
        }
    }
}
