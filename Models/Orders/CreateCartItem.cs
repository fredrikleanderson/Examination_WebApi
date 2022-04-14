namespace Examination_WebApi.Models.Orders
{
    public class CreateCartItem
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
    }
}
