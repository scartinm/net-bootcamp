using InventoryDC;
using InventoryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBC
{
    public class CategoryLogic
    {
        CategoryDAL datos = new CategoryDAL();
        public IEnumerable<Category> SelectCategoryLogic()
        {

            return datos.SelectCategories();
        }
    }
}
