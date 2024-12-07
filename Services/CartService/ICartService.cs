using eCommerceWebApiBackEnd.Cart;
using eCommerceWebApiBackEnd.Dto;
using eCommerceWebApiBackEnd.Shared;

namespace eCommerceWebApiBackEnd.Services.CartService
{
    public interface ICartService
    {
        Task<ServiceResponse<List<CartProductResponseDto>>> GetCartProducts(List<CartItem> cartItems);
    }
}
