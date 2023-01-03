namespace ShopManagement.Contracts.Orders
{
    public interface IOrderApplication
    {
        long PlaceOrder(CartDetail Cart);
        string PaymentSucceeded(long orderId, long refId);
        double GetAmountBy(long Id);
    }
}
