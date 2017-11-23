

namespace InventoryDC
{
    using System.Data.Entity;
    using InventoryEntities;

    public class InvetoryAppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
