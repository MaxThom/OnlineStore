using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class FixProductRepository : IProductsRepository
    {
        private FixDbContext context = new FixDbContext();
        public IEnumerable<Product> Products { get { return FixDbContext.Products; }}


        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                product.ProductID = (FixDbContext.Products.Select(p => p.ProductID).DefaultIfEmpty(0).Max() + 1);
                FixDbContext.Products.Add(product);
            }
            else
            {
                Product dbEntry = FixDbContext.Products.Find(p => p.ProductID == product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Category = product.Category;
                    dbEntry.Price = product.Price;
                }
            }
           
        }
        public Product DeleteProduct(int productID)
        {
            Product dbEntry = FixDbContext.Products.Find(p => p.ProductID == productID);
            if (dbEntry != null)
            {
                FixDbContext.Products.Remove(dbEntry);
            }

            return dbEntry;
        }
    }

   

}
