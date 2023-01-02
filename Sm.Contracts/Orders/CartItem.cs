namespace ShopManagement.Contracts.Orders
{
    public class CartItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? PicturePath { get; set; }
        public double UnitPrice { get; set; }
        public int Count { get; set; }
        public double TotalPrice { get; set; }
        public bool IsInStock { get; set; }
        public double DiscountAmount { get; set; }
        public long DiscountRate { get; set; }
        public double ItemPayAmount { get; set; }

        public void CalculateTotalPrice()
        {
            TotalPrice = UnitPrice * Count;
        }
    }
}
