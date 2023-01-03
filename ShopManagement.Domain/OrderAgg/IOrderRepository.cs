using MyFramework.Domain;

namespace ShopManagement.Domain.OrderAgg
{
    public interface  IOrderRepository : IRepository<long,OrderModel>
    {
        double GetAmountBy(long Id);
    }
}
