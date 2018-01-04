namespace InventoryDC.Migrations
{
    using InventoryEntities;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<InventoryDC.InvetoryAppDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InventoryDC.InvetoryAppDBContext context)
        {

            //context.Category.AddOrUpdate(x => x.CategoryId,
            //    new Category() { CategoryId = 1, CategoryName = "Gaseosas", Description = "Bebidas gaseosas, refrescos" },
            //    new Category() { CategoryId = 2, CategoryName = "Dulces", Description = "Confites, chicles, chocolates, etc." });
            //context.SaveChanges();
            //context.Product.AddOrUpdate(x => x.ProductId,
            //    new Product() { ProductId = 1, Name = "Fanta Colita 1L", CategoryId = 1, Price = 1000, Quantity = 100 },
            //    new Product() { ProductId = 2, Name = "Snickers", CategoryId = 1, Price = 500, Quantity = 100 });
            //context.SaveChanges();
            //context.Users.AddOrUpdate(x => x.UserId,
            //    new User() { UserId = 1, UserName = "Steph", Password = "123", IsAdmin = true },
            //    new User() { UserId = 2, UserName = "David", Password = "1234", IsAdmin = false });
            //context.SaveChanges();

            //context.Client.AddOrUpdate(x => x.ClientId,
            //    new Client() { ClientId = 1, ClientName = "Juanito", Lastname = "Ramirez", Phone = "22-23-44-33", status = true},
            //    new Client() { ClientId = 2, ClientName = "Lola", Lastname = "Perez", Phone = "26-92-46-08", status = false});
            //context.SaveChanges();
            //context.Invoice.AddOrUpdate(x => x.InvoiceId,
            //    new Invoice() { InvoiceId = 1, ClientId = 1, InvoiceDate = DateTime.Now, UserId = 1 },
            //    new Invoice() { InvoiceId = 2, ClientId = 2, InvoiceDate = DateTime.Now, UserId = 1 });
            //context.SaveChanges();
            //context.ProductPerInvoice.AddOrUpdate(x => x.ProductXIvoiceId,
            //    new ProductPerInvoice() { ProductXIvoiceId = 1, ProductId = 1, InvoiceId = 1, Quantity = 2 });

            //context.SaveChanges();
        }
    }
}
