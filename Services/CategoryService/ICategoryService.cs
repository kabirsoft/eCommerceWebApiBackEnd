using eCommerceWebApiBackEnd.Models;
using eCommerceWebApiBackEnd.Shared;

namespace eCommerceWebApiBackEnd.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<Category>>> GetAllCategories();
    }
}
