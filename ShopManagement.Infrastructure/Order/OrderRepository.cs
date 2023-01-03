using MyFramework.Infrastructure;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Infrastructure.ProductCategory.DbContextModel;

namespace ShopManagement.Infrastructure.EfCore.Order
{
    public class OrderRepository : RepositoryBase<long, OrderModel>, IOrderRepository
    {
        private readonly ShopContext? _shopContext;

        public OrderRepository(ShopContext? shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public double GetAmountBy(long id)
        {
            var Order = _shopContext.orders.Select(x => new { x.PayAmount, x.Id }).FirstOrDefault(x => x.Id == id);
          
            if(Order != null)
            {
                return Order.PayAmount;
            }
            else
            {
                return 0;
            }
        }
    }
}
