namespace InventoryDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SP_Clients_insert : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("SP_Clients_Insert",
                p => new {
                    name = p.String(),
                    lastName = p.String(),
                    phone = p.String(),
                }
                , @"INSERT INTO Clients (clientName, lastName, phone, status)
                   VALUES (@name, @lastName, @phone, 'true')");
        }

        public override void Down()
        {
            DropStoredProcedure("SP_Clients_Add");
        }
    }
}
