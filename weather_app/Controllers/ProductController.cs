/* Example Controller*/

using Microsoft.AspNetCore.Mvc;

namespace weather_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Returns all products.
        /// </summary>
        /// <returns>List of products.</returns>
        [HttpGet]
        public IEnumerable<string> GetProducts()
        {
            return new List<string> { "Apple", "Banana", "Cherry" };
        }

        /// <summary>
        /// Returns a single product by ID.
        /// </summary>
        /// <param name="id">The product ID.</param>
        /// <returns>The requested product.</returns>
        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            var products = new List<string> { "Apple", "Banana", "Cherry" };
            if (id < 0 || id >= products.Count)
                return "Product not found";
            return products[id];
        }
    }
}