﻿
using eCommerceWebApiBackEnd.Cart;
using eCommerceWebApiBackEnd.Dto;
using eCommerceWebApiBackEnd.Services.CartService;
using eCommerceWebApiBackEnd.Shared;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceWebApiBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("products")]
        public async Task<ActionResult<ServiceResponse<List<CartProductResponseDto>>>> GetCartProducts(List<CartItem> cartItems)
        {
            var result = await _cartService.GetCartProducts(cartItems);
            return Ok(result);
        }

    }
}
