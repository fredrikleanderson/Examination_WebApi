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

        public async Task<ActionResult<IEnumerable<ReadOrder>>> ReadOrders()
        {
            List<ReadOrder> result = new();

            IEnumerable<OrderEntity> orders = await _context.Orders.Include(x => x.OrderItems)
                .Include(x => x.User).ThenInclude(x => x.Address).ToListAsync();

            foreach (OrderEntity order in orders)
            {
                List<ReadOrderItem> orderItems = new();

                foreach (OrderItemEntity orderItem in await _context.OrderItems.Where(x => x.OrderId == order.Id).ToListAsync())
                {
                    orderItems.Add(new ReadOrderItem
                    {
                        Id = orderItem.Id,
                        ArticleNumber = orderItem.ArticleNumber,
                        ProductName = orderItem.ProductName,
                        Quantity = orderItem.Quantity
                    });
                }

                result.Add(new ReadOrder
                {
                    Id = order.Id,
                    FirstName = order.User.FirstName,
                    LastName = order.User.LastName,
                    StreetAddress = order.User.Address.StreetAddress,
                    PostalCode = order.User.Address.PostalCode,
                    City = order.User.Address.City,
                    OrderStatus = order.OrderStatus,
                    OrderItems = orderItems.ToArray()
                });
            }

            return result;
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

            return new OkResult();
        }

        public async Task SetOrderStatusToShipped(int orderId)
        {
            OrderEntity? order = await _context.Orders.FindAsync(orderId);

            if (order == null)
            {
                return;
            }

            order.OrderStatus = OrderStatus.Shipped;
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return;
        }

        public async Task FileOrder(int orderId)
        {
            OrderEntity? order = await _context.Orders.FindAsync(orderId);

            if (order == null)
            {
                return;
            }

            order.OrderStatus = OrderStatus.Filed;
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return;
        }
    }
}
