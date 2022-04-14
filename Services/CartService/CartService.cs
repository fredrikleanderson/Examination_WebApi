using Examination_WebApi.Data;
using Examination_WebApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examination_WebApi.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly DataContext _context;

        public CartService(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> AddCart(int userId)
        {
            CartEntity? cart = await _context.Carts.FirstOrDefaultAsync(x => x.UserId == userId);

            if (cart != null)
            {
                return new ConflictObjectResult("User already has a cart");
            }

            cart = new CartEntity
            {
                UserId = userId
            };

            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();

            return new OkObjectResult("Cart added to user");
        }

        public async Task<ActionResult> DeleteCart(int userId)
        {
            CartEntity? cart = _context.Carts.FirstOrDefault(x => x.UserId == userId);

            if (cart == null)
            {
                return new NotFoundObjectResult("Cart not found");
            }

            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();

            return new OkObjectResult("Cart removed");
        }
    }
}
