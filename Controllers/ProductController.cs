using eCommerceWebApiBackEnd.Data;
using eCommerceWebApiBackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceWebApiBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }

        // GET: api/product
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProduct()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }
    }
}
