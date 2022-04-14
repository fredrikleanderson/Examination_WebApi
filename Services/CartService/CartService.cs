using Examination_WebApi.Data;
using Examination_WebApi.Models.Entities;
using Examination_WebApi.Models.Orders;
using Examination_WebApi.Services.InventoryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examination_WebApi.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly DataContext _context;
        private readonly IInventoryService _inventoryService;

        public CartService(DataContext context, IInventoryService inventoryService)
        {
            _context = context;
            _inventoryService = inventoryService;
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

        public async Task<ActionResult<ReadCartItem>> AddItemToCart(CreateCartItem model)
        {
            UserEntity? user = await _context.Users.Include(x => x.Cart).FirstOrDefaultAsync(x => x.Id == model.UserId);

            if (user == null || user.Cart == null)
            {
                return new BadRequestObjectResult("Unable to find user/cart.");
            }

            ProductEntity? product = await _context.Products.FirstOrDefaultAsync(x => x.Id == model.ProductId);

            if (product == null)
            {
                return new BadRequestObjectResult("Unable to find product");
            }

            CartItemEntity? cartItem = await _context.CartItems.FirstOrDefaultAsync(x => x.CartId == user.Cart.Id
            && x.Product.Id == model.ProductId);

            if(cartItem != null)
            {
                cartItem.Quantity += model.Quantity;
                _context.Entry(cartItem).State = EntityState.Modified;
            }
            else
            {
                cartItem = new CartItemEntity
                {
                    Quantity = model.Quantity,
                    ProductId = product.Id,
                    CartId = user.Cart.Id
                };
                await _context.CartItems.AddAsync(cartItem);
            }

            await _context.SaveChangesAsync();
            await _inventoryService.DecrementProductInventoryAsync(product.Id, model.Quantity);

            return new OkObjectResult(new ReadCartItem
            {
                Id = cartItem.Id,
                ArticleNumber = product.Id,
                ProductName = product.Name,
                Quantity = cartItem.Quantity
            });
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

        public async Task<ActionResult<IEnumerable<ReadCartItem>>> GetCart(int userId)
        {
            List<ReadCartItem> result = new();

            CartEntity? cart = await _context.Carts.Include(x => x.CartItems).ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if(cart == null)
            {
                return new NotFoundObjectResult("Cart not found");
            }

            foreach (CartItemEntity item in cart.CartItems)
            {
                result.Add(new ReadCartItem
                {
                    Id = item.Id,
                    ArticleNumber = item.ProductId,
                    ProductName = item.Product.Name,
                    Quantity = item.Quantity
                });
            }

            return result;
        }
    }
}
