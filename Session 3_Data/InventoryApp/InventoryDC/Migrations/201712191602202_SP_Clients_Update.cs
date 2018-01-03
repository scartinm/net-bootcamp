namespace InventoryDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SP_Clients_Update : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("SP_Clients_Update",
                p => new {
                    clientId = p.Int(),
                    clientName = p.String(),
                    clientLastName = p.String(),
                    clientPhone = p.String(),
                }
                ,@"UPDATE Clients
                   SET clientName = @clientName,
                       lastName = @clientLastName,
                       phone = @clientPhone
                   WHERE clientId = @clientId");
        }
        
        public override void Down()
        {
            DropStoredProcedure("SP_Clients_Update");
        }
    }
}
