using Examination_WebApi.Models.Orders;
using Examination_WebApi.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace Examination_WebApi.Services.CartService
{
    public interface ICartService
    {
        Task<ActionResult> AddCart(int userId);
        Task<ActionResult> DeleteCart(int userId);
        Task RemoveItemFromCart(int userId, RemoveCartItem model);
        Task DeleteAllCartItemsWithDeletedProduct(int productId);
        Task<ActionResult<IEnumerable<ReadCartItem>>> GetCart(int userId);
        Task<ActionResult<ReadCartItem>> AddItemToCart(CreateCartItem model);
        Task ClearCartAfterPurchase(int userId);
    }
}
