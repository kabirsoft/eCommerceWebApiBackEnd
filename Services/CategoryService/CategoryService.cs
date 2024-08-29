using eCommerceWebApiBackEnd.Data;
using eCommerceWebApiBackEnd.Models;
using eCommerceWebApiBackEnd.Shared;
using Microsoft.EntityFrameworkCore;

namespace eCommerceWebApiBackEnd.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Category>>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return new ServiceResponse<List<Category>>
            {
                Data = categories
            };              
        }
    }
}
