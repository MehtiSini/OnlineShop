namespace ShopManagement.Contracts.Orders
{
    public class OrderItemsViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string? ProductPicture { get; set; }
        public string? Product { get; set; }
        public int Count { get; set; }
        public long DiscountRate { get; set; }
        public double UnitPrice { get; set; }
        public long OrderId { get; set; }
    }
}
