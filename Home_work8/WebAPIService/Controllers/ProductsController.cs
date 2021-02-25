using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIService.Models;

namespace WebAPIService.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product{Id = 1, Name = "Leapton TEA", Category = "Баккалея", Price = 120},
            new Product{Id = 2, Name = "Майский чай", Category = "Баккалея", Price = 100},
            new Product{Id = 3, Name = "Дрель Интерскол", Category = "Инструменты", Price = 3000}
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
