using InventoryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDC
{
    public class CategoryDAL
    {
        InvetoryAppDBContext db = new InvetoryAppDBContext();

        public IEnumerable<Category> SelectCategories()
        {
            //InvetoryAppDBContext db = new InvetoryAppDBContext();
            return db.Category.ToList();
        }
    }
}
