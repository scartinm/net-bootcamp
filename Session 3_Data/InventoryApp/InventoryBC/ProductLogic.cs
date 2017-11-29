
namespace InventoryBC
{
    using InventoryDC;
    using InventoryEntities;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductLogic
    {
        public IEnumerable<Product> SelectProductsLogic()
        {
            ProductDAL datos = new ProductDAL();
            return datos.SelectProducts();
        }
    }
}
