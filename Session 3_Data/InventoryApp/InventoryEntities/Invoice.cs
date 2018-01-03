

namespace InventoryEntities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        [Required]
        [DataType("datetime2")]
        public DateTime InvoiceDate { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual Client Client { get; set; }
        public virtual User User { get; set; }
    }

    public class InvoiceReportResult {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string ClientName { get; set; }
        public string UserName { get; set; }

    }

   
   
    public class InvoiceTop3 {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Total_Quantity { get; set;}
        public string CategoryName { get; set; }
    }
}
