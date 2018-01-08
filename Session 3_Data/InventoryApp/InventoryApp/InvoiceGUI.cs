

namespace InventoryApp
{
    using InventoryBC;
    using System;

    class InvoiceGUI
    {
        static InvoiceLogic userLogic = new InvoiceLogic();
        static ProductLogic productLogic = new ProductLogic();
        static int userId = UserGUI.userId;

        public static void createInvoice() {

            bool creandoFactura = true;
            
            var fecha = DateTime.Now;
            int invoiceId;
            int clientId;
            int productIdPorAgregar;
            int cantidadPorDescontar;
            int opcion;
            string seguir;
            bool compraValida;


            Console.WriteLine("\t\t*****CREAR NUEVA FACTURA*****\n");
            ClientGUI.ClientSelect();
            Console.Write("\nSeleccione el código del cliente a facturar: ");


            clientId =Convert.ToInt32( Console.ReadLine());
            
            //crea un invoice
            userLogic.CreateInvoice(userId, clientId, fecha);
            //selecciona el ultimo invoice creado para añadirle productos
            invoiceId = userLogic.SelectLastInvoiceCreated();

            Console.Write("Número de factura: {0}\n\n", invoiceId);


            while (creandoFactura == true)
            {
                ProductGUI.PrintInventory();
                Console.WriteLine("****Ingreso de productos a la factura*****");
                Console.Write("Código producto: ");
                productIdPorAgregar = Convert.ToInt32(Console.ReadLine());
                Console.Write("Cantidad: ");
                cantidadPorDescontar = Convert.ToInt32(Console.ReadLine());
                seguir = "";
                    
                compraValida = productLogic.ValidadCantidadPorComprar(productIdPorAgregar, cantidadPorDescontar);

                if (compraValida)
                {
                    
                    Console.Write("se agregó el producto exitosamente a la factura, desea agregar otro? si/no: ");
                    seguir = Console.ReadLine();
                    if (seguir == "si")
                    {
                        creandoFactura = true;
                    }
                    else if(seguir =="no")
                    {
                        creandoFactura = false;
                    }

                }
                else
                {
                    while (!compraValida)
                    {
                        Console.WriteLine("La cantidad que desea comprar sobrepasa la cantidad en existencia.");
                        Console.WriteLine("1) Modificar cantidad");
                        Console.WriteLine("2) Ingresar otro producto");
                        Console.WriteLine("3) Salir de la compra");
                        Console.Write("Que desea realizar?: ");
                        opcion = Convert.ToInt32(Console.ReadLine());

                        switch (opcion)
                        {
                            case 1:
                                Console.Write("cantidad: ");
                                cantidadPorDescontar = Convert.ToInt32(Console.ReadLine());
                                compraValida = productLogic.ValidadCantidadPorComprar(productIdPorAgregar, cantidadPorDescontar);
                                if (compraValida)
                                {
                                    Console.Write("se agregó el producto exitosamente a la factura, desea agregar otro? si/no: ");
                                    seguir = Console.ReadLine();
                                    if (seguir == "si")
                                    {
                                        creandoFactura = true;
                                    }
                                    else if (seguir == "no")
                                    {
                                        creandoFactura = false;
                                    }
                                }
                                

                                break;
                            case 2:
                                creandoFactura = true;
                                compraValida = true;
                                break;
                            case 3:
                                compraValida = true;
                                creandoFactura = false;
                                break;
                            default:
                                break;
                        }
                    }
                    
                }
                       
            }


        }
    }
}
