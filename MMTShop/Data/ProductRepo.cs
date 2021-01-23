using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MMTShop.Models;

namespace MMTShop.Data
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetProducts();

        Product GetProductById(int Id);

        IEnumerable<Product> GetProductsByCategory(int Id);

    }
}
