using DemoSqlServerWithWebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoSqlServerWithWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(AppDbContext _context) : ControllerBase
    {

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts() => 
            Ok(await _context.Products.ToListAsync());

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(product);
            //return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }
    }
}
