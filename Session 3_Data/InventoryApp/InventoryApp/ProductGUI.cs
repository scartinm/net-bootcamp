
namespace InventoryApp
{
    using InventoryBC;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class ProductGUI
    {
        static ProductLogic prodData = new ProductLogic();
        static CategoryGUI catData = new CategoryGUI();
        public static void PrintInventory()
        {
            
            var cod = "Código";
            var nombre = "Nombre";
            var precio = "Precio";
            var cantidad = "Cantidad";
            var prodList = prodData.SelectProductsLogic();

            Console.WriteLine("\t \t********** LISTA DE PRODUCTOS **********\n"); 
            Console.WriteLine(AlignCentre(cod, 10) + " | " + AlignCentre(nombre, 30) + " | " + AlignCentre(precio, 10) + " | " + AlignCentre(cantidad, 10) + " | ");
            Console.WriteLine("-----------------------------------------------------------------------");
            foreach (var x in prodList)
            {
                Console.WriteLine(AlignCentre(x.ProductId.ToString(), 10) + " | " + AlignCentre(x.Name, 30) + " | " + AlignCentre(x.Price.ToString(), 10) + " | " + AlignCentre(x.Quantity.ToString(), 10) + " | ");
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

        internal static void CrearProducto()
        {
            string nombre;
            int precio;
            int cantidad;
            int categoria;
            Console.Clear();
            Console.WriteLine("\n*****Ingreso de productos*****\n");
            Console.Write("Nombre del producto: ");
            nombre = Console.ReadLine();
            Console.Write("\nPrecio del producto: ");
            precio =Convert.ToInt32(Console.ReadLine());
            Console.Write("\nCantidad del producto en existencia: ");
            cantidad = Convert.ToInt32(Console.ReadLine());
            catData.categorySelect();
            Console.Write("\n Categoría del producto: ");
            categoria = Convert.ToInt32(Console.ReadLine());
            
            prodData.CrearProducto(nombre, precio, cantidad,categoria);

        }

        internal static void ProdQuantityUpdate()
        {
            int ProductId;
            int cantidad;
            PrintInventory();
            Console.Write("\nSeleccione el código del producto que desea modificar: ");
            ProductId = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nNueva cantidad: ");
            cantidad = Convert.ToInt32(Console.ReadLine());
            prodData.ProdQuantityUpdateLogic(ProductId, cantidad);

            Console.WriteLine("\n Inventario Actualizado\n -----------------------");
            PrintInventory();
        }
    }
}
