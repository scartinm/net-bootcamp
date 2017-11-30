

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
            

            Console.WriteLine("1) Imprimir inventario");
            Console.WriteLine("2) Crear un nuevo usuario");
            Console.WriteLine("2) Crear un nuevo producto");
            Console.WriteLine("3) Modificar cantidad de un producto");
            Console.WriteLine("4) Eliminar un producto");
            Console.WriteLine("5) Ingresar un cliente nuevo");
            Console.WriteLine("6) Editar un cliente");
            Console.WriteLine("7) Eliminar un cliente");
            Console.WriteLine("8) Generar reportes\n");
            Console.Write("Ingrese el número de la opción a realizar: ");
            int option = Int32.Parse(Console.ReadLine());
            ChoseAdminOption(option);
        }

        public void ChoseAdminOption(int option) {
            switch (option)
            {
                case 1:
                    //Imprimir el inventario
                    break;
                case 2:
                    //Crear un nuevo usuario
                    
                    UserGUI.UserAdd();
                    break;
                case 3:
                    //Modificar cantidad de un producto
                    break;
                case 4:
                    //Eliminar un producto
                    break;
                case 5:
                    //Cliente nuevo
                    break;
                case 6:
                    //Editar cliente
                    break;
                case 7:
                    //Eliminar cliente
                    break;
                case 8:
                    //Generar reportes
                    break;
                default:
                    //valor incorrecto volverlo a intentar
                    break;
            }
        }

        public void UserAdd() {
            

        }

        public void PrintInvetory() {
           List<Product> productList = productData.SelectProductsLogic().ToList();

        }

    }
}
