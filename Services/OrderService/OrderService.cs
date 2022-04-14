using Examination_WebApi.Data;
using Examination_WebApi.Models.Entities;
using Examination_WebApi.Models.Orders;
using Microsoft.AspNetCore.Mvc;

namespace Examination_WebApi.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;

        public OrderService(DataContext context)
        {
            _context = context;
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
    }
}
