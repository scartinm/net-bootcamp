﻿
namespace InventoryBC
{
    using InventoryDC;
    using InventoryEntities;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class ProductLogic
    {
        ProductDAL datos = new ProductDAL();
        CommonDALFunctions DALFunc = new CommonDALFunctions();

        public IEnumerable<Product> SelectProductsLogic()
        {
            
            return datos.SelectProducts();
            datos.RefreshAll();

        }

        public void CrearProducto(string nombre, int precio, int cantidad, int categoria)
        {
            //aqui va la lógica para crear un producto
            datos.ProductInsert(nombre,precio,cantidad,categoria);
            datos.RefreshAll();
        }

        public void ProdQuantityUpdateLogic(int productId, int cantidad)
        {
            datos.ProdQuantityUpdateDAL(productId, cantidad);
            datos.RefreshAll();
        }

        public void ProductDeleteLogic(int productId)
        {
            datos.productDelete(productId);
        }
    }
}
