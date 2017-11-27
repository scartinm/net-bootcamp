

namespace InventoryDC
{
    using System.Data.Entity;
    using InventoryEntities;

    public class InvetoryAppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<ProductPerInvoice> ProductPerInvoice { get; set; }

  

    }
}
