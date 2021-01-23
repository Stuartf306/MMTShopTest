using MMTShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTShop.Data
{
    public class DemoProductRepo : IProductRepo
    {
        public Product GetProductById(int Id)
        {
            return new Product
            {
                ID = Id,
                SKU = 10000,
                Name = "Lamp",
                Description = "Table lamp",
                Price = 15.00
            };
        }

        public IEnumerable<Product> GetProducts()
        {
            Product[] products = new Product[]
            {
            new Product {ID = 1, SKU = 10000, Name = "Lamp",
            Description = "Table lamp", Price=15.00},
            new Product {ID = 2, SKU = 20000, Name = "Lawnmower",
            Description = "Electric lawnmower", Price=49.99},
            new Product {ID = 3, SKU = 30000, Name = "iPad",
            Description = "Apple iPad", Price=230.00},
            new Product {ID = 4, SKU = 40000, Name = "Kettlebell",
            Description = "15kg Kettlebell", Price=21.50},
            new Product {ID = 5, SKU = 50000, Name = "Lego",
            Description = "100 piece Lego set", Price=30.00}
            };

            return products;
        }

        public IEnumerable<Product> GetProductsByCategory(int Id)
        {
            Product[] products = new Product[]
            {
            new Product {ID = 1, SKU = 10000, Name = "Lamp",
            Description = "Table lamp", Price=15.00},
            new Product {ID = 2, SKU = 20000, Name = "Lawnmower",
            Description = "Electric lawnmower", Price=49.99},
            new Product {ID = 3, SKU = 30000, Name = "iPad",
            Description = "Apple iPad", Price=230.00},
            new Product {ID = 4, SKU = 40000, Name = "Kettlebell",
            Description = "15kg Kettlebell", Price=21.50},
            new Product {ID = 5, SKU = 50000, Name = "Lego",
            Description = "100 piece Lego set", Price=30.00}
            };

            return products;
        }
    }
}
