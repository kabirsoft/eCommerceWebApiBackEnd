using eCommerceWebApiBackEnd.Data;
using eCommerceWebApiBackEnd.Models;
using eCommerceWebApiBackEnd.Services.ProductService;
using eCommerceWebApiBackEnd.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceWebApiBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {        
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {            
            _productService = productService;
        }

        // GET: api/product
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProduct()
        {
            var result = await _productService.GetAllProductsAsync();
            return Ok(result);
        }

        //Get: api/product/{productId}
        [HttpGet("{productId}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProductById(int productId)
        {
            var result = await _productService.GetProductByIdAsync(productId);
            if(result.Data == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //Get: api/product/category/{categoryUrl}
        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategory(string categoryUrl)
        {
            var result = await _productService.GetProductsByCategory(categoryUrl);
            if(result.Data == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
