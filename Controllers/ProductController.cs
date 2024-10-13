using eCommerceWebApiBackEnd.Dto;
using eCommerceWebApiBackEnd.Models;
using eCommerceWebApiBackEnd.Services.ProductService;
using eCommerceWebApiBackEnd.Shared;
using Microsoft.AspNetCore.Mvc;

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
            if (result.Data == null)
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
            if (result.Data == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //Get: api/product/search/{searchText}
        [HttpGet("search/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> SearchProducts(string searchText)
        {
            var result = await _productService.SearchProducts(searchText);
            if (result.Data == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //Get: api/product/search/{searchText}/{page}
        [HttpGet("search/{searchText}/{page}")]
        public async Task<ActionResult<ServiceResponse<ProductPaginationDto>>> SearchProductsWithPagination(string searchText, int page = 1)
        {
            var result = await _productService.SearchProductsWithPagination(searchText, page);
            if (result.Data == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //Get: api/product/suggestions/{searchText}
        [HttpGet("suggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> SearchProductsSuggestions(string searchText)
        {
            var result = await _productService.SearchProductsSuggestions(searchText);
            if (result.Data == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //Get: api/product/featured
        [HttpGet("featured")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetFeaturedProducts()
        {
            var result = await _productService.GetFeaturedProducts();
            if (result.Data == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
