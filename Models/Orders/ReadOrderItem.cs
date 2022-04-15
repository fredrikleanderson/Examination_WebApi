namespace Examination_WebApi.Models.Orders
{
    public class ReadOrderItem
    {
        public int Id { get; set; }
        public int ArticleNumber { get; set; }
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
