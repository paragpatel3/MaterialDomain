using MatStore.Domain.Abstract;
using MatStore.Domain.Entities;
using System.Collections.Generic;

namespace MatStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {

        // uses instance of EFDBContext to retrieve data from connected db using EF. 
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public void SaveInfo(Product newProduct)
        {
            if (newProduct.ProductID == 0)
            {
                context.Products.Add(newProduct);
            }
            else
            {
                Product newEntry = context.Products.Find(newProduct.ProductID);
                if (newEntry != null)
                {
                    newEntry.Name = newProduct.Name;
                    newEntry.Description = newProduct.Description;
                    newEntry.Price = newProduct.Price;
                    newEntry.Category = newProduct.Category;
                    newEntry.Image = newProduct.Image;
                }
            }
            context.SaveChanges();
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products.Find(productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }

}