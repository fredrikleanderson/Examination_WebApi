namespace Examination_WebApi.Models.Orders
{
    public class ReadOrder
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string StreetAddress { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string OrderStatus { get; set; } = null!;
        public DateTime Date { get; set; }
        public ReadOrderItem[] OrderItems { get; set; } = null!;
    }
}
