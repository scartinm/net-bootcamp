namespace InventoryDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class getClientNameByID : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("SP_Client_GetName_ByClientId",
                p => new {
                    clientId = p.Int()
                },
                body: @"SELECT ClientName + Lastname as ClientName 
                        FROM Clients
                        WHERE clientId = @clientId");
        }
        
        public override void Down()
        {
            DropStoredProcedure("SP_Client_GetName_ByClientId");
        }
    }
}
