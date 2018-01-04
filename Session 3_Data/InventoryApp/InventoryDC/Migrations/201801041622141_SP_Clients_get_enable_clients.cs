namespace InventoryDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SP_Clients_get_enable_clients : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("SP_Clients_get_status_true",
                body: @"SELECT * FROM Clients
                        WHERE status = 1");
        }
        
        public override void Down()
        {
            DropStoredProcedure("SP_Clients_get_status_true");
        }
    }
}
