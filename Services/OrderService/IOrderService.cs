using Examination_WebApi.Models.Orders;
using Microsoft.AspNetCore.Mvc;

namespace Examination_WebApi.Services.OrderService
{
    public interface IOrderService
    {
        Task<ActionResult<GetOrderId>> CreateOrder(PlaceOrder model);
        Task<ActionResult> UpdateOrder(CreateOrderItem model);
        Task<ActionResult<IEnumerable<ReadOrder>>> ReadOrders();
        Task SetOrderStatusToShipped(int orderId);
        Task FileOrder(int orderId);
    }
}
