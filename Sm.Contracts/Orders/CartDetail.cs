namespace ShopManagement.Contracts.Orders
{
    public class CartDetail
    {
        public double DiscountAmount { get; set; }
        public double PayAmount { get; set; }
        public double TotalAmount { get; set; }
        public int PaymentMethod { get; set; }
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
        public void SetPaymentMethod(int paymentMethod )
        {
            PaymentMethod = paymentMethod;
        }

    }
}
