using Examination_WebApi.Models.Orders;
using Examination_WebApi.Services.OrderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examination_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Authorize(Roles =("Admin,User"))]
        public async Task<ActionResult<GetOrderId>> PostOrder(PlaceOrder model)
        {
            return await _orderService.CreateOrder(model);
        }

        [HttpPut]
        [Authorize(Roles =("Admin,User"))]
        public async Task<ActionResult> PutOrderItem(CreateOrderItem model)
        {
            return await _orderService.UpdateOrder(model);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = ("Admin"))]
        public async Task ShipOrder(int id)
        {
            await _orderService.SetOrderStatusToShipped(id);
        }

        [HttpGet]
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult<IEnumerable<ReadOrder>>> GetOrders()
        {
            return await _orderService.ReadOrders();
        }

    }
}
