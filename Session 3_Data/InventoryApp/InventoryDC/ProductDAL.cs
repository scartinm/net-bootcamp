

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

        public IEnumerable<Product> SelectProducts()
        {
            return db.Product.ToList();
        }

        //Insertar un producto
        public void ProductInsert(string nombre, int precio, int cantidad, int categoria) {
            SqlParameter paramNombre = new SqlParameter("@name", nombre);
            SqlParameter paramPrecio = new SqlParameter("@price", precio);
            SqlParameter paramCantidad = new SqlParameter("@quantity", cantidad);
            SqlParameter paramCategory = new SqlParameter("@category", categoria);
            db.Database.ExecuteSqlCommand("SP_Product_Add @name, @price, @quantity, @category", paramNombre, paramPrecio, paramCantidad, paramCategory);
            Console.WriteLine("Producto agregado exitosamente.");
            //DALFunc.RefreshAll();
        }

        public void ProdQuantityUpdateDAL(int productId, int cantidad)
        {
            SqlParameter paramProductId = new SqlParameter("@productId", productId);
            SqlParameter paramCantidad = new SqlParameter("@quantity", cantidad);
            db.Database.ExecuteSqlCommand("SP_Product_Update_ById @productId, @quantity", paramProductId, paramCantidad);
            Console.WriteLine("Producto actualizado exitosamente.");
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
