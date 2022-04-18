namespace Examination_WebApi.Models.Orders
{
    public class PlaceOrder
    {
        public int UserId { get; set; }
        public string OrderStatus { get; set; } = null!;
    }
}
