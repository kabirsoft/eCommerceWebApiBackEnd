using eCommerceWebApiBackEnd.Dto;
using eCommerceWebApiBackEnd.Models;
using eCommerceWebApiBackEnd.Shared;

namespace eCommerceWebApiBackEnd.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetAllProductsAsync();
        Task<ServiceResponse<Product>> GetProductByIdAsync(int productId);
        Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl);
        Task<ServiceResponse<List<Product>>> SearchProducts(string searchText);
        Task<ServiceResponse<ProductPaginationDto>> SearchProductsWithPagination(string searchText, int page);
        Task<ServiceResponse<List<string>>> SearchProductsSuggestions(string searchText);
        Task<ServiceResponse<List<Product>>> GetFeaturedProducts();
    }
}
