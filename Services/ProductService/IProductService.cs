using eCommerceWebApiBackEnd.Dto;
using eCommerceWebApiBackEnd.Models;
using eCommerceWebApiBackEnd.Shared;

namespace eCommerceWebApiBackEnd.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<ProductPaginationDto>> GetAllProductsWithPagination(int page);
        Task<ServiceResponse<Product>> GetProductByIdAsync(int productId);
        Task<ServiceResponse<ProductPaginationDto>> GetProductsByCategoryWithPagination(string categoryUrl, int page);
        Task<ServiceResponse<ProductPaginationDto>> GetFeaturedProductsWithPagination(int page);
        Task<ServiceResponse<ProductPaginationDto>> SearchProductsWithPagination(string searchText, int page);
        Task<ServiceResponse<List<string>>> SearchProductsSuggestions(string searchText);

        // These are not used now, becoz pagination functonality is implemented
        Task<ServiceResponse<List<Product>>> GetAllProductsAsync();
        Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl);
        Task<ServiceResponse<List<Product>>> GetFeaturedProducts();
        Task<ServiceResponse<List<Product>>> SearchProducts(string searchText);
        // End These are not used now, becoz pagination functonality is implemented
    }
}
