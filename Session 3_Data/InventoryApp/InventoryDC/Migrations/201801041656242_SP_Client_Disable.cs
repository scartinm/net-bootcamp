namespace InventoryDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SP_Client_Disable : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("SP_Client_Disable",
                p => new {
                    clientId = p.Int(),
                },
                body: @"UPDATE Clients
                        SET status = 'false'
                        WHERE ClientId = @clientId");
        }
        
        public override void Down()
        {
            DropStoredProcedure("SP_Client_Disable");
        }
    }
}
