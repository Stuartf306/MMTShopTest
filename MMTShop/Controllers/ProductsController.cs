using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using MMTShop.Models;
using MMTShop.Data;

namespace MMTShop.Controllers
{
    //api/Products
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DemoProductRepo _repo = new DemoProductRepo();

        //GET api/Products
        [HttpGet]
        public ActionResult <IEnumerable<Product>> GetProducts()
        {
            var products = _repo.GetProducts();
            return Ok(products);
        }

        //GET api/Products/{id}
        [HttpGet("{id}")]
        public ActionResult <Product> GetProductById(int id)
        {
            var product = _repo.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

    }
}
