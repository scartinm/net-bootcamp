

namespace InventoryDC
{
    using InventoryEntities;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    public class ProductDAL
    {
        InvetoryAppDBContext db = new InvetoryAppDBContext();
        CommonDALFunctions DALFunc = new CommonDALFunctions();

        public List<Product> SelectProducts()
        {
            var sqlResult = db.Database.SqlQuery<Product>("SP_Product_Get_Status_True").ToList();
            return sqlResult;
        }

        //Insertar un producto
        public void ProductInsert(string nombre, int precio, int cantidad, int categoria) {
            SqlParameter paramNombre = new SqlParameter("@name", nombre);
            SqlParameter paramPrecio = new SqlParameter("@price", precio);
            SqlParameter paramCantidad = new SqlParameter("@quantity", cantidad);
            SqlParameter paramCategory = new SqlParameter("@category", categoria);
            db.Database.ExecuteSqlCommand("SP_Product_Add @name, @price, @quantity, @category", paramNombre, paramPrecio, paramCantidad, paramCategory);
            Console.WriteLine("\nProducto agregado exitosamente.\n");
            //DALFunc.RefreshAll();
        }

        public void productDelete(int productId)
        {
            SqlParameter paramProductId = new SqlParameter("@productId", productId);
            db.Database.ExecuteSqlCommand("SP_Product_Disable @productId", paramProductId);
            Console.WriteLine("\nProducto eliminado exitosamente.\n");
        }

        public void ProdQuantityUpdateDAL(int productId, int cantidad)
        {
            SqlParameter paramProductId = new SqlParameter("@productId", productId);
            SqlParameter paramCantidad = new SqlParameter("@quantity", cantidad);
            db.Database.ExecuteSqlCommand("SP_Product_Update_ById @productId, @quantity", paramProductId, paramCantidad);
            Console.WriteLine("\nProducto actualizado exitosamente.\n");
            //DALFunc.RefreshAll();
           
        }

        public void RefreshAll()
        {

            foreach (var entity in db.ChangeTracker.Entries())
            {
                entity.Reload();
            }
        }
    }
}
