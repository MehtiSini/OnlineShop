namespace ShopManagement.Contracts.Orders
{
    public interface IOrderApplication
    {
        long PlaceOrder(CartDetail Cart);
        string PaymentSucceeded(long orderId, long refId);
        double GetAmountBy(long Id);
        void Confirm(long id);
        void Cancel(long id);
        List<OrderViewModel> Search(OrderSearchModel searchModel);
        List<OrderItemsViewModel> GetItems(long OrderId);
    }
}
