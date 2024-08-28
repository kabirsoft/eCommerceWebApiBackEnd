using eCommerceWebApiBackEnd.Models;
using eCommerceWebApiBackEnd.Shared;

namespace eCommerceWebApiBackEnd.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetAllProductsAsync();
        Task<ServiceResponse<Product>> GetProductByIdAsync(int productId);
    }
}
