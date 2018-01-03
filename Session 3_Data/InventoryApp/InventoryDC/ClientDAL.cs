
namespace InventoryDC
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using InventoryEntities;
    using System.Linq;

    public class ClientDAL
    {
        InvetoryAppDBContext db = new InvetoryAppDBContext();

        public void clientAddDAL(string clientName, string clientLastName, string phone)
        {
            SqlParameter paramClientName = new SqlParameter("@clientName", clientName);
            SqlParameter paramClientLastName = new SqlParameter("@clientLastName", clientLastName);
            SqlParameter paramPhone = new SqlParameter("@phone", phone);

            db.Database.ExecuteSqlCommand("SP_Clients_Add @clientName, @clientLastName, @phone", paramClientName, paramClientLastName, paramPhone);
            Console.WriteLine("El cliente se ingresó correctamente");
        }

        
        public IEnumerable<Client> SelectClient()
        {
            return db.Client.ToList();
        }

        public void ClientUpdateDAL(int cod, string name, string lastname, string phone)
        {
            SqlParameter paramClientId = new SqlParameter("@clientId", cod);
            SqlParameter paramClientName = new SqlParameter("@clientName", name);
            SqlParameter paramClientLastName = new SqlParameter("@clientLastName", lastname);
            SqlParameter paramPhone = new SqlParameter("@phone", phone);

            db.Database.ExecuteSqlCommand("SP_Clients_Update @clientId, @clientName, @clientLastName, @phone", paramClientId, paramClientName, paramClientLastName, paramPhone);
            Console.WriteLine("\nCliente actualizado exitosamente\n");
            

        }

        public string GetClientNameById(int ClientId) {

            SqlParameter paramClientId = new SqlParameter("@clientId", ClientId);

            var sqlResult = db.Database.SqlQuery<string>("SP_Client_GetName_ByClientId @clientId", paramClientId).FirstOrDefault<string>() ;
            
            return sqlResult;

        }

        public void RefreshAll()
        {

            foreach (var entity in db.ChangeTracker.Entries())
            {
                entity.Reload();
            }
        }
    }
}
