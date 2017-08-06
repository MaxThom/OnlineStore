using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;

namespace Domain.Concrete
{
    public class FixDbContext
    {
        public static List<Product> Products { get; set; }

        public FixDbContext()
        {
            if (Products == null)
            {
                Products = new List<Product>();
                Products.Add(new Product { ProductID = 1, Name = "Football", Price = 25, Category = "Sport", Description = "Un ballon de football américain" });
                Products.Add(new Product { ProductID = 2, Name = "Surf Board", Price = 179, Category = "Sport", Description = "Un surf pour Hawai" });
                Products.Add(new Product { ProductID = 3, Name = "Mazda 3", Price = 24000, Category = "Voiture", Description = "Une voiture sportive, économique et sécuritaire" });
                Products.Add(new Product { ProductID = 4, Name = "CrossTrek", Price = 30000, Category = "Voiture", Description = "Un camion parfait pour la ville" });
                Products.Add(new Product { ProductID = 5, Name = "Tesla", Price = 45000, Category = "Voiture", Description = "Une voiture electrique et tres securitaire" });
                Products.Add(new Product { ProductID = 6, Name = "Kia", Price = 20000, Category = "Voiture", Description = "Petite voiture parfait pour la ville" });
                Products.Add(new Product { ProductID = 7, Name = "Volt", Price = 23000, Category = "Voiture", Description = "Voiture hybride" });
                Products.Add(new Product { ProductID = 8, Name = "Full PC", Price = 1505, Category = "Electronique", Description = "Full Gaming Pc " });
                Products.Add(new Product { ProductID = 9, Name = "Keyboard", Price = 95, Category = "Electronique", Description = "Best keyboard made by razor !" });
            }
        }
    }
}
