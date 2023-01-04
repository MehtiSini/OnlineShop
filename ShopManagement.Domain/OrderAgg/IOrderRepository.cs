using MyFramework.Domain;
using ShopManagement.Contracts.Orders;

namespace ShopManagement.Domain.OrderAgg
{
    public interface  IOrderRepository : IRepository<long,OrderModel>
    {
        double GetAmountBy(long Id);
        List<OrderViewModel> Search(OrderSearchModel searchModel);
        List<OrderItemsViewModel> GetItems(long OrderId);
    }
}
