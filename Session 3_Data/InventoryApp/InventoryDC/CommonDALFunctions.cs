using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDC
{
    public class CommonDALFunctions
    {
        InvetoryAppDBContext db = new InvetoryAppDBContext();

        public void RefreshAll() {

            foreach (var entity in db.ChangeTracker.Entries())
            {
                entity.Reload();
            }
        }
    }
}
