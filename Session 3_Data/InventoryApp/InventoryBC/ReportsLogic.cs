
namespace InventoryBC
{
    using InventoryDC;
    using InventoryEntities;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class ReportsLogic
    {
        ReportsDAL reportData = new ReportsDAL();

        public bool ValidarFecha(string fecha) {
            
            bool validar;
            Regex regex = new Regex(@"^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$");

            validar = regex.IsMatch(fecha);
            return validar;
            ;
        }

        public DateTime ConvertirFecha(string Fecha)
        {
            DateTime fechaFinal = Convert.ToDateTime(Fecha);
            
            return fechaFinal;
        }

        
        public List<InvoiceReportResult> ReportePorFechas(string stringFechaDesde, string stringFechaHasta)
        {
            DateTime FechaDesde;
            DateTime FechaHasta;
            bool ValidaDesde = ValidarFecha(stringFechaDesde);
            bool ValidaHasta = ValidarFecha(stringFechaHasta);
            List<InvoiceReportResult> invoiceResult;

            if (ValidaDesde == true && ValidaHasta == true)
            {
                FechaDesde = ConvertirFecha(stringFechaDesde);
                FechaHasta = ConvertirFecha(stringFechaHasta);
                
                invoiceResult = SelectInvoicesByDate(FechaDesde, FechaHasta);

                Console.Clear();
                Console.WriteLine("*****Fechas utilizadas: {0} , {1}*****\n",FechaDesde, FechaHasta);

            }
            else {

                invoiceResult = SelectInvoice();
                Console.Clear();
                Console.WriteLine("*****El formato de las fechas es incorrecto, imprimiendo todos los invoices***** \n");
            }

            return invoiceResult;
        }

        public List<InvoiceReportResult> SelectInvoicesByDate(DateTime fechaDesde, DateTime fechaHasta) {
            var invoiceResult = reportData.SelectInvoicesByDate(fechaDesde, fechaHasta);
            return invoiceResult;
        }

        public List<InvoiceReportResult> SelectInvoice() {

            var invoiceResult = reportData.SelectInvoices();
            return invoiceResult;
        }


        public List<InvoiceReportResult> SelectInvoicesByCustomerID(int codigoCliente)
        {
            var InvoicesByCustomerIdList = reportData.SelectInvoicesByCustomerID(codigoCliente);
            return InvoicesByCustomerIdList;
        }

        public List<InvoiceTop3> selectTop3Invoices (int codigoCliente)
        {
            var Top3InvoicesList = reportData.SelectTop3Invoices(codigoCliente);
            return Top3InvoicesList;

        }

        public int SelectMontoTotalInvoices(int codigoCliente) {
            var MontoTotal = reportData.SelectMontoTotal(codigoCliente);
            return MontoTotal;
        }

        public int SelectPromedioInvoices(int codigoCliente) {
            var Promedio = reportData.selectPromedio(codigoCliente);
            return Promedio;
        }
    }
}
