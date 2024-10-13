using eCommerceWebApiBackEnd.Models;

namespace eCommerceWebApiBackEnd.Dto
{
    public class ProductPaginationDto
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }        
    }
}
