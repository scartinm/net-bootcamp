

namespace InventoryDC
{
    using InventoryEntities;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductDAL
    {
        InvetoryAppDBContext db = new InvetoryAppDBContext();

        public IEnumerable<Product> SelectProducts()
        {
            //InvetoryAppDBContext db = new InvetoryAppDBContext();
            return db.Product.ToList();
        }
    }
}
