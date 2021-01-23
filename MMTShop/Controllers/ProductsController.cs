using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using MMTShop.Models;
using System.Data.SqlClient;

namespace MMTShop.Controllers
{
    public class ProductsController : ControllerBase
    {
        //GET api/Products
        [Route("api/[controller]")]
        [HttpGet]
        public ActionResult <IEnumerable<Product>> GetFeaturedProducts() //Get all available featured products
        {
            List<Product> products = new List<Product>();

            var connString = "Server=DESKTOP-K7G724A\\SQLEXPRESS;Database=MMTShop;Trusted_Connection=True;";
            using (SqlConnection sqlconn = new SqlConnection(connString))
            {
                using (SqlCommand sqlcom = new SqlCommand("sp_GetFeaturedProducts", sqlconn))
                {
                    sqlconn.Open();
                    sqlcom.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader sqlReader = sqlcom.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        Product newProduct = new Product();
                        newProduct.ID = int.Parse(sqlReader["ProductID"].ToString());
                        newProduct.SKU = int.Parse(sqlReader["SKU"].ToString());
                        newProduct.Name = sqlReader["Name"].ToString();
                        newProduct.Description = sqlReader["Description"].ToString();
                        newProduct.Price = double.Parse(sqlReader["Price"].ToString());

                        products.Add(newProduct);
                    }
                }
            }

            if (products.Count > 0)
                return Ok(products);
            else
                return NotFound();
        }

    }
}
