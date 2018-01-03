using InventoryBC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp
{
    public class ReportsGUI
    {
        static ReportsLogic reportsLogic = new ReportsLogic();
        static ClientLogic clientLogic = new ClientLogic();

        public static void displayReportsMenu()
        {
            
            int opcion;

            Console.Clear();
            Console.WriteLine("**************REPORTES**************");
            Console.WriteLine("1) Invoices por fechas");
            Console.WriteLine("2) Invoices por código del cliente\n");
            Console.Write("Seleccione la opción del reporte que desea visualizar: ");
            opcion = Convert.ToInt32(Console.ReadLine());
            chooseReportOption(opcion);
           
        }

        public static void chooseReportOption(int opcion) {
            string StringFechaDesde;
            string StringFechaHasta;
            int codigoCliente;

            var cod = "Código";
            var fecha = "Fecha";
            var cliente = "Cliente";
            var usuario = "Usuario";
            var producto = "Producto";
            var cantTotal = "Cantidad";
            var categoria = "Categoría";


            switch (opcion)
            {
                case 1:
                    // Imprime reporte Invoices por fecha
                    Console.Clear();

                    Console.WriteLine("*****Ingrese las fechas del reporte con formato dd/mm/aaaa *****\n");

                    Console.Write("Fecha desde: ");
                    StringFechaDesde = Console.ReadLine();
                    Console.Write("Fecha hasta: ");
                    StringFechaHasta = Console.ReadLine();

                    var report = reportsLogic.ReportePorFechas(StringFechaDesde, StringFechaHasta);
                    
                    Console.WriteLine("\t \t********** LISTA DE INVOICES **********\n");
                    Console.WriteLine(AlignCentre(cod, 7) + " | " + AlignCentre(fecha, 25) + " | " + AlignCentre(cliente, 30) + " | " + AlignCentre(usuario, 10) + " | ");
                    Console.WriteLine("-----------------------------------------------------------------------------------");
                    foreach (var x in report)
                    {
                        Console.WriteLine(AlignCentre(x.InvoiceId.ToString(), 7) + " | " + AlignCentre(x.InvoiceDate.ToString(), 25) + " | " + AlignCentre(x.ClientName.ToString(), 30) + " | " + AlignCentre(x.UserName.ToString(), 10) + " | ");
                    }

                    break;
                case 2:
                    //Imprime reporte Invoice por customerId

                    Console.Clear();
                    Console.WriteLine("**********REPORTE POR CODIGO DE CLIENTE**********\n");
                    ClientGUI.ClientSelect();
                    Console.Write("\nSeleccione el código del cliente a consultar: ");
                    codigoCliente = Convert.ToInt32(Console.ReadLine());

                    var clientName = clientLogic.ClientNamebyId(codigoCliente);
                    var montoTotal = reportsLogic.SelectMontoTotalInvoices(codigoCliente);
                    var promedio = reportsLogic.SelectPromedioInvoices(codigoCliente);
                    var listaTop3 = reportsLogic.selectTop3Invoices(codigoCliente);
                    var InvoicesPorClientId = reportsLogic.SelectInvoicesByCustomerID(codigoCliente);

                    Console.Clear();

                    Console.WriteLine("\t \tREPORTE DE INVOICES DEL CLIENTE: {0}", clientName);
                    Console.WriteLine("-----------------------------------------------------------------------------------");
                    

                    Console.WriteLine("LISTA DE INVOICES:\n");
                    Console.WriteLine(AlignCentre(cod, 7) + " | " + AlignCentre(fecha, 25) + " | " + AlignCentre(cliente, 30) + " | " + AlignCentre(usuario, 10) + " | ");
                    Console.WriteLine("-----------------------------------------------------------------------------------");
                    foreach (var x in InvoicesPorClientId)
                    {
                        Console.WriteLine(AlignCentre(x.InvoiceId.ToString(), 7) + " | " + AlignCentre(x.InvoiceDate.ToString(), 25) + " | " + AlignCentre(x.ClientName.ToString(), 30) + " | " + AlignCentre(x.UserName.ToString(), 10) + " | ");
                    }
                    Console.WriteLine("-----------------------------------------------------------------------------------");
                    Console.WriteLine("TOP 3 PRODUCTOS COMPRADOS POR EL CLIENTE:\n");

                    Console.WriteLine(AlignCentre(cod, 7) + " | " + AlignCentre(producto, 25) + " | " + AlignCentre(cantTotal, 30) + " | " + AlignCentre(categoria, 10) + " | ");
                    Console.WriteLine("-----------------------------------------------------------------------------------");
                    foreach (var x in listaTop3)
                    {
                        Console.WriteLine(AlignCentre(x.ProductId.ToString(), 7) + " | " + AlignCentre(x.Name.ToString(), 25) + " | " + AlignCentre(x.Total_Quantity.ToString(), 30) + " | " + AlignCentre(x.CategoryName.ToString(), 10) + " | ");
                    }
                    Console.WriteLine("-----------------------------------------------------------------------------------");
                    
                    Console.WriteLine("MONTO TOTAL DE COMPRAS:     ${0}", montoTotal);
                    Console.WriteLine("PROMEDIO TOTAL DE COMPRAS:  ${0}", promedio);
                    Console.WriteLine("-----------------------------------------------------------------------------------");
                    break;
                default:
                    //SE TIENE QUE AGREGAR ALGUNA EXCEPCIÓN PARA QUE NO TRUENE.
                    break;
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
    }
}
