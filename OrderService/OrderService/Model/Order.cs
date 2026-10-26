namespace OrderService.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending";
        public decimal TotalAmount { get; set; }
        public string ShippingAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalAddress { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

    }
}
