

namespace InventoryApp
{
    using System;
    using InventoryBC;
    using InventoryEntities;
    using System.Linq;
    using System.Collections.Generic;

    public class AdminModule
    {
        ProductLogic productData = new ProductLogic();
        UserLogic userData = new UserLogic();
        //UserGUI UserGUI = new UserGUI();
        
        public void DisplayAdminModule() {


            Console.WriteLine("*******Seleccione la opción a realizar*******\n");
                Console.WriteLine("1) Imprimir inventario");
                Console.WriteLine("2) Crear un nuevo usuario");
                Console.WriteLine("3) Crear un nuevo producto");
                Console.WriteLine("4) Modificar cantidad de un producto");
                Console.WriteLine("5) Eliminar un producto");
                Console.WriteLine("6) Mostrar lista de clientes");
                Console.WriteLine("7) Ingresar un cliente nuevo");
                Console.WriteLine("8) Editar un cliente");
                Console.WriteLine("9) Eliminar un cliente");
                Console.WriteLine("10) Generar reportes\n");
                Console.Write("Ingrese el número de la opción a realizar: ");
                int option = Int32.Parse(Console.ReadLine());
                ChoseAdminOption(option);

            
            
        }

        public void ChoseAdminOption(int option) {
            bool salir = false;
            do
            {
                switch (option)
                {
                    case 1:
                        //Imprimir el inventario
                        ProductGUI.PrintInventory();
                        Continuar();
                        
                        break;
                    case 2:
                        //Crear un nuevo usuario

                        UserGUI.UserAdd();
                        Continuar();
                        break;
                    
                    case 3:
                        //Crear un producto
                        ProductGUI.CrearProducto();
                        Continuar();
                        break;
                    case 4:
                        //Modificar cantidad del producto
                        ProductGUI.ProdQuantityUpdate();
                        Continuar();
                        break;
                    case 5:
                        //Eliminar un producto
                        Console.Clear();
                        Console.WriteLine("La página se encuentra bajo mantenimiento, gracias por su comprensión!");
                        Continuar();
                        break;
                    case 6:
                        //Mostrar lista de clientes
                        ClientGUI.ClientSelect();
                        Continuar();
                        break;
                        
                    case 7:
                        //Ingresar cliente nuevo
                        ClientGUI.ClientAdd();
                        Continuar();
                        break;

                    case 8:
                        ClientGUI.ClientUpdate();
                        Continuar();
                        break;
                    case 9:
                        //Eliminar un cliente
                        Console.Clear();
                        Console.WriteLine("La página se encuentra bajo mantenimiento, gracias por su comprensión!");
                        Continuar();
                        break;
                    case 10:
                        //Entrar al menú de los reportes.
                        ReportsGUI.displayReportsMenu();
                        Continuar();
                        break;
                    default:
                        //valor incorrecto volverlo a intentar
                        salir = true;

                        break;
                }
            } while (!salir);
            
        }

        public void UserAdd() {
            

        }

        public void PrintInvetory() {
           List<Product> productList = productData.SelectProductsLogic().ToList();

        }

        public void Continuar()
        {
            Console.WriteLine();
            Console.WriteLine(">>> presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            DisplayAdminModule();

        }

    }
}
