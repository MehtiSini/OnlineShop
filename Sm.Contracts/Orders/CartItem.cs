namespace ShopManagement.Contracts.Orders
{
    public class CartDetail
    {
        public double DiscountAmount { get; set; }
        public double PayAmount { get; set; }
        public double TotalAmount { get; set; }
        public List<CartItem>? CartItems { get; set; }

        public CartDetail()
        {
            CartItems = new List<CartItem>();
        }

        public void Add(CartItem cart)
        {
            CartItems.Add(cart);
            TotalAmount += cart.TotalPrice;
            PayAmount += cart.ItemPayAmount;
            DiscountAmount += cart.DiscountAmount;
        }

    }

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
        public double DiscountRate { get; set; }
        public double ItemPayAmount { get; set; }

        public void CalculateTotalPrice()
        {
            TotalPrice = UnitPrice * Count;
        }
    }
}
