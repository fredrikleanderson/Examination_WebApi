using Examination_WebApi.Data;
using Examination_WebApi.Models.Entities;
using Examination_WebApi.Models.Orders;
using Examination_WebApi.Services.CartService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examination_WebApi.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly ICartService _cartService;

        public OrderService(DataContext context, ICartService cartService)
        {
            _context = context;
            _cartService = cartService;
        }

        public async Task<ActionResult<GetOrderId>> CreateOrder(PlaceOrder model)
        {
            OrderEntity order = new OrderEntity
            {
                UserId = model.UserId,
                OrderRecieved = model.OrderRecieved,
                OrderStatus = model.OrderStatus,
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return new GetOrderId
            {
                Id = order.Id
            };
        }

        public async Task<ActionResult> UpdateOrder(CreateOrderItem model)
        {
            OrderItemEntity orderItem = new OrderItemEntity
            {
                Quantity = model.Quantity,
                ArticleNumber = model.ProductId,
                ProductName = model.ProductName,
                OrderId = model.OrderId
            };

            OrderEntity? order = await _context.Orders.FindAsync(model.OrderId);

            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();

            if (order != null)
            {
                await _cartService.ClearCartAfterPurchase(order.UserId);
            }

            return new OkResult();
        }
    }
}
