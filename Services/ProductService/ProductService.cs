using eCommerceWebApiBackEnd.Data;
using eCommerceWebApiBackEnd.Models;
using eCommerceWebApiBackEnd.Shared;
using Microsoft.EntityFrameworkCore;

namespace eCommerceWebApiBackEnd.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context) 
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Product>>> GetAllProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                .Include(p => p.ProductVariant)
                .ToListAsync()
            };

            return response;
        }
        public async Task<ServiceResponse<Product>> GetProductByIdAsync(int productId)
        {
            var response = new ServiceResponse<Product>();
            var product = await _context.Products
                .Include(p => p.ProductVariant)
                .ThenInclude(p => p.ProductType)
                .FirstOrDefaultAsync(p => p.Id == productId);
            if(product == null)
            {
                response.Success = false;
                response.Message = $"Product with Id: {productId} not found.";
            }
            else
            {
                response.Data = product;                
            }
            return response;
        }
        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                  .Include(p => p.Category)
                  .Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
                  .Include(p => p.ProductVariant)
                  .ToListAsync()
            }; 
            return response;
        }
        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
        {
            var products = await FindProductsBySearchText(searchText);
            List<string> suggestions = new List<string>();
            foreach (var product in products)
            {
                if(product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    suggestions.Add(product.Title);
                }
                if (product.Description != null)
                {
                    var punctuation = product.Description.Where(Char.IsPunctuation).Distinct().ToArray();
                    var words = product.Description.Split().Select(x => x.Trim(punctuation));
                    foreach (var word in words)
                    {
                        if(word.Contains(searchText, StringComparison.OrdinalIgnoreCase) && !suggestions.Contains(word))
                        {
                            suggestions.Add(word);
                        }
                    }
                }
            }
            return new ServiceResponse<List<string>> { Data = suggestions };
        }
        public async Task<ServiceResponse<List<Product>>> SearchProducts(string searchText)
        {
            var response = new ServiceResponse<List<Product>>();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                response.Data = new List<Product>(); // Return an empty list if searchText is null or whitespace
                return response;
            }
            
            response.Data = await FindProductsBySearchText(searchText);

            return response;
        }
        private async Task<List<Product>> FindProductsBySearchText(string searchText)
        {
            searchText = searchText.ToLower(); // Make searchText case-insensitive once
            return await _context.Products
                .Include(p => p.ProductVariant)
                .ThenInclude(v => v.ProductType)
                .Where(p => p.Title.ToLower().Contains(searchText)
                         || p.Description.ToLower().Contains(searchText)
                         || p.ProductVariant.Any(v => v.ProductType.Name.ToLower().Contains(searchText)))
                .ToListAsync();
        }
    }
}
