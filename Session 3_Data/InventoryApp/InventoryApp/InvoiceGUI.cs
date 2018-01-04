

namespace InventoryApp
{
    using InventoryBC;
    using System;

    class InvoiceGUI
    {
        static InvoiceLogic userLogic = new InvoiceLogic();
        static int userId = UserGUI.userId;

        public static void createInvoice() {

            
            var fecha = DateTime.Now;
            int invoiceId;
            

            Console.WriteLine("\t\t*****CREAR NUEVA FACTURA*****\n");
            //ClientGUI.ClientSelect();
            Console.Write("Seleccione el código del cliente a facturar: ");

            int clientId =Convert.ToInt32( Console.ReadLine());

            Console.WriteLine("cliente: {0}", clientId);
            Console.WriteLine("userId: {0}", userId);
            Console.WriteLine("fecha: {0}", fecha);

            //crea un invoice
            //userLogic.CreateInvoice(userId, clientId, fecha);
            //selecciona el ultimo invoice creado para añadirle productos
            //invoiceId = userLogic.SelectLastInvoiceCreated();

            //Console.Write("este es el ultimo invoice creado {0}", invoiceId);


        }
    }
}
