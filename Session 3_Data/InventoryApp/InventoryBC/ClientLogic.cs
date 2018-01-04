

namespace InventoryBC
{
    using InventoryDC;
    using InventoryEntities;
    using System;
    using System.Collections.Generic;

    public class ClientLogic
    {
        ClientDAL clientData = new ClientDAL();

        public void clientAddLogic(string clientName, string clientLastName, string phone)
        {
            clientData.clientAddDAL(clientName, clientLastName, phone);
        }

        public IEnumerable<Client>  SelectClientLogic()
        {
            return clientData.SelectClient();
            clientData.RefreshAll();
        }

        public void ClientUpdate(int cod, string name, string lastname, string phone)
        {
            clientData.ClientUpdateDAL(cod, name, lastname, phone);
            clientData.RefreshAll();
        }

        public string ClientNamebyId(int ClientId) {
            var ClientName = clientData.GetClientNameById(ClientId);
            return ClientName;
        }

        public void clientDisable(int clientId)
        {
            clientData.clientDisable(clientId);
        }
    }

}
