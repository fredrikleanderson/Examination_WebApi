namespace Examination_WebApi.Models.Orders
{
    public class CreateOrderItem
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
