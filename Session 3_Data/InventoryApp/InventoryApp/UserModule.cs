using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp
{
    public class UserModule
    {
        static int userId = UserGUI.userId;

        static public void DisplayUserModule() {
            Console.WriteLine("*******Seleccione la opción a realizar*******\n");
            Console.WriteLine("1) Imprimir inventario");
            Console.WriteLine("2) Crear una nueva factura");
            Console.WriteLine("3) Generar reportes");
            Console.Write("Ingrese el número de la opción a realizar: ");

            int option = Int32.Parse(Console.ReadLine());
            ChoseAdminOption(option);
        }

        static private void ChoseAdminOption(int option)
        {
            bool salir = false;
            do
            {
                switch (option)
                {
                    case 1:
                        //Imprimir el inventario
                        Console.Clear();
                        ProductGUI.PrintInventory();
                        Continuar();

                        break;
                    case 2:
                        //crear una nueva factura
                        Console.Clear();
                        InvoiceGUI.createInvoice();
                        Continuar();
                        break;

                    case 3:
                        
                        break;
                    default:
                        //valor incorrecto volverlo a intentar
                        salir = true;
                        break;
                }
            } while (!salir);
        }

        static public void Continuar()
        {
            Console.WriteLine();
            Console.WriteLine(">>> presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            DisplayUserModule();

        }
    }
}
