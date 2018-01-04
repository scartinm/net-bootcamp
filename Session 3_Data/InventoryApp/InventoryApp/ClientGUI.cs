using InventoryBC;
using System;

namespace InventoryApp
{
    public class ClientGUI
    {
        static ClientLogic clientData = new ClientLogic();

        public static void ClientAdd()
        {

            string ClientName;
            string clientLastName;
            string phone;

            Console.Clear();
            Console.WriteLine("******Ingreso de un nuevo cliente******\n");
            Console.Write("Nombre: ");
            ClientName = Console.ReadLine();
            Console.Write("Apellido: ");
            clientLastName = Console.ReadLine();
            Console.Write("Teléphono (xxxx-xx-xx): ");
            phone = Console.ReadLine();

            clientData.clientAddLogic(ClientName, clientLastName, phone);
        }



        public static void ClientSelect()
        {

            var cod = "Código";
            var nombre = "Nombre";
            var apellido = "Apellido";
            var telefono = "Teléfono";
            var clientList = clientData.SelectClientLogic();

            

            Console.WriteLine("\t \t********** LISTA DE CLIENTES **********\n");
            Console.WriteLine(AlignCentre(cod, 10) + " | " + AlignCentre(nombre, 20) + " | " + AlignCentre(apellido, 15) + " | " + AlignCentre(telefono, 20) + " | ");
            Console.WriteLine("-----------------------------------------------------------------------------");
            foreach (var x in clientList)
            {
                Console.WriteLine(AlignCentre(x.ClientId.ToString(), 10) + " | " + AlignCentre(x.ClientName, 20) + " | " + AlignCentre(x.Lastname.ToString(), 15) + " | " + AlignCentre(x.Phone.ToString(), 20) + " | ");
            }

        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }


        }

        internal static void ClientUpdate()
        {
            int cod;
            string name;
            string lastname;
            string phone;

            Console.Clear();
            ClientSelect();
            Console.Write("\n\nSeleccione el código del cliente que desea cambiar: ");
            cod = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nombre: ");
            name = Console.ReadLine();
            Console.Write("Apellido: ");
            lastname = Console.ReadLine();
            Console.Write("Teléphono (xxxx-xx-xx): ");
            phone = Console.ReadLine();

            clientData.ClientUpdate(cod, name, lastname, phone);
            Console.WriteLine("LISTA DE CLIENTES ACTUALIZADA: ");
            ClientSelect();
        }

        internal static void ClientDelete()
        {
            int clientId;

            Console.Clear();
            Console.WriteLine("\t\t*****Eliminar un cliente******\n");
            ClientSelect();
            Console.Write("\nSeleccione el código del cliente que desea eliminar: ");
            clientId =Convert.ToInt32(Console.ReadLine());

            clientData.clientDisable(clientId);
            Console.WriteLine("\nCliente eliminado exitosamente ");
        }
    }

}
