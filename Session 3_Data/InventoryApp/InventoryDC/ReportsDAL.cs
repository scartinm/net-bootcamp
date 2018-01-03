

namespace InventoryDC
{
    using InventoryEntities;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    public class ReportsDAL
    {
        InvetoryAppDBContext db = new InvetoryAppDBContext();
       

        public List<InvoiceReportResult> SelectInvoicesByDate(DateTime fechaDesde, DateTime fechaHasta)
        {
            SqlParameter paramDesde = new SqlParameter("@Desde", fechaDesde);
            SqlParameter paramHasta = new SqlParameter("@Hasta", fechaHasta);


            var sqlResult = db.Database.SqlQuery<InvoiceReportResult>("SP_Invoices_Select_By_Date @Desde, @Hasta", paramDesde, paramHasta);
            return sqlResult.ToList();
        }

        public List<InvoiceReportResult> SelectInvoices()
        {
            var sqlResult = db.Database.SqlQuery<InvoiceReportResult>("SP_Select_Invoices");
            return sqlResult.ToList();
        }

        public List<InvoiceReportResult> SelectInvoicesByCustomerID(int customerId) {

            SqlParameter paramCustomer = new SqlParameter("@customerId", customerId);

            var sqlResult = db.Database.SqlQuery<InvoiceReportResult>("SP_Invoices_Select_ByCustomerId @customerId", paramCustomer);
            return sqlResult.ToList();
        }

        public Int32 SelectMontoTotal (int customerId){
            
            SqlParameter paramCustomer = new SqlParameter("@customerId", customerId);

            Int32 sqlResult = db.Database.SqlQuery<Int32>("SP_Invoices_Get_GrandTotal_ByCustomerId @customerId", paramCustomer).Single();
            
            return sqlResult;
        }

        public Int32 selectPromedio(int customerId) {

            SqlParameter paramCustomer = new SqlParameter("@customerId", customerId);

            Int32 sqlResult = db.Database.SqlQuery<Int32>("SP_Invoices_AverageSpentOnInvoices_ByCustomer @customerId", paramCustomer).Single();

            return sqlResult;
        }

        public List<InvoiceTop3> SelectTop3Invoices(int customerId)
        {

            SqlParameter paramCustomer = new SqlParameter("@customerId", customerId);

            var sqlResult = db.Database.SqlQuery<InvoiceTop3>("SP_Invoices_GetTop3Products_ByCustomerId @customerId", paramCustomer).ToList();
            return sqlResult;
        }

    }
}
