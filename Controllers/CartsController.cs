using Examination_WebApi.Models.Orders;
using Examination_WebApi.Models.Users;
using Examination_WebApi.Services.CartService;
using Examination_WebApi.Services.InventoryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examination_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
         }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<ReadCartItem>> AddItemToCart(CreateCartItem model)
        {
            return await _cartService.AddItemToCart(model);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<IEnumerable<ReadCartItem>>> GetCart(int id)
        {
            return await _cartService.GetCart(id);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, User")]
        public async Task DeleteCartItem(int id, RemoveCartItem model)
        {
            await _cartService.RemoveItemFromCart(id, model);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, User")]
        public async Task ClearCart(int id)
        {
            await _cartService.ClearCartAfterPurchase(id);
        }

    }
}
