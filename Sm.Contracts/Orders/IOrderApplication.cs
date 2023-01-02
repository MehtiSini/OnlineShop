namespace ShopManagement.Contracts.Orders
{
    public interface IOrderApplication
    {
        long PlaceOrder(CartDetail Cart);
        void PaymentSucceded(long id, long refId);
    }
}
