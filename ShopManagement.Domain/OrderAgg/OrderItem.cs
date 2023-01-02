using MyFramework.Domain;

namespace ShopManagement.Domain.OrderAgg
{
    public class OrderItem : EntityBase
    {
      
        public long ProductId { get; private set; }
        public int Count { get; private set; }
        public long DiscountRate { get; private set; }
        public double UnitPrice { get; private set; }
        public long  OrderId { get; private set; }
        public OrderModel?  Order { get; private set; }

        public OrderItem(long productId, int count, long discountRate, 
            double unitPrice)
        {
            ProductId = productId;
            Count = count;
            DiscountRate = discountRate;
            UnitPrice = unitPrice;
        }
    }
}