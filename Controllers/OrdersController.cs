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
    }
}
