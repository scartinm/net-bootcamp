using InventoryDC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBC
{

    public class InvoiceLogic
    {
        InvoiceDAL invoiceDAL = new InvoiceDAL();

        public void CreateInvoice(int userId, int clientId, DateTime fecha)
        {
            invoiceDAL.CreateInvoiceDAL(userId,clientId,fecha);
        }

        public int SelectLastInvoiceCreated()
        {
           int invoiceId = invoiceDAL.SelectLastCreatedInvoice();
            return invoiceId;
        }
    }
}
