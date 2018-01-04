

namespace InventoryDC
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class InvoiceDAL
    {
        InvetoryAppDBContext db = new InvetoryAppDBContext();

        public void CreateInvoiceDAL(int userId, int clientId, DateTime fecha)
        {
            SqlParameter paramUserId = new SqlParameter("@userId", userId);
            SqlParameter paramClientId = new SqlParameter("@clientId", clientId);
            SqlParameter paramFecha = new SqlParameter("@fecha", fecha);

            db.Database.ExecuteSqlCommand("SP_Invoice_Insert @userId, @clientId, @fecha", paramUserId, paramClientId,paramFecha);

        }

        public int SelectLastCreatedInvoice()
        {
            Int32 sqlResult = db.Database.SqlQuery<Int32>("SP_Invoice_Select_Last_Added").Single();

            return sqlResult;
        }
    }
}
