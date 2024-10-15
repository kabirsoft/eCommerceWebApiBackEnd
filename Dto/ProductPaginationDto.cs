using eCommerceWebApiBackEnd.Models;

namespace eCommerceWebApiBackEnd.Dto
{
    public class ProductPaginationDto
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }        
    }
}
