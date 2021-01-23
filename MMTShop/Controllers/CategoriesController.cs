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
    public class CategoriesController : ControllerBase
    {
        //GET api/Categories
        [Route("api/[controller]")]
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories() //Get all available categories
        {
            List<Category> categories = new List<Category>();

            var connString = "Server=DESKTOP-K7G724A\\SQLEXPRESS;Database=MMTShop;Trusted_Connection=True;";
            using (SqlConnection sqlconn = new SqlConnection(connString))
            {
                using (SqlCommand sqlcom = new SqlCommand("sp_GetAllAvailableCategories", sqlconn))
                {
                    sqlconn.Open();
                    sqlcom.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader sqlReader = sqlcom.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        Category newCategory = new Category();
                        newCategory.ID = int.Parse(sqlReader["CategoryID"].ToString());
                        newCategory.Name = sqlReader["Name"].ToString();

                        categories.Add(newCategory);
                    }
                }
            }

            if (categories.Count > 0)
                return Ok(categories);
            else
                return NotFound();
        }

        //GET api/Categories/id
        [Route("api/[controller]/{id}")]
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProductsByCategory(int id) //Get all available products by selected category
        {
            List<Product> products = new List<Product>();

            var connString = "Server=DESKTOP-K7G724A\\SQLEXPRESS;Database=MMTShop;Trusted_Connection=True;";
            using (SqlConnection sqlconn = new SqlConnection(connString))
            {
                using (SqlCommand sqlcom = new SqlCommand("sp_GetAllProductsByCategory", sqlconn))
                {
                    sqlconn.Open();
                    sqlcom.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlcom.Parameters.AddWithValue("@CategoryID", id);

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
