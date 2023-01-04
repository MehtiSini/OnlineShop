using MyFramework.Infrastructure;
using MyFramework.Tools;
using MyFramework.Tools.Authentication;
using ShopManagement.Contracts.Orders;
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

            if (Order != null)
            {
                return Order.PayAmount;
            }
            else
            {
                return 0;
            }
        }

        public List<OrderItemsViewModel> GetItems(long OrderId)
        {
            var Order = _shopContext.orders.FirstOrDefault(x => x.Id == OrderId);
            var Products = _shopContext.products.Select(x => new { x.Id, x.Name, x.PicturePath }).ToList();

            if (Order == null) return new();

            ///
            var OrderItems = Order.Items.Select(x => new OrderItemsViewModel
            {
                Id=x.Id,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                Count = x.Count,
                DiscountRate = x.DiscountRate,
                UnitPrice = x.UnitPrice
            }).ToList();

            foreach (var item in OrderItems)
            {
                item.Product = Products.FirstOrDefault(x => x.Id == item.ProductId).Name;
                item.ProductPicture = Products.FirstOrDefault(x => x.Id == item.ProductId).PicturePath;
            }

            return OrderItems;
        }

        public List<OrderViewModel> Search(OrderSearchModel searchModel)
        {
            var Query = _shopContext.orders.Select(x => new OrderViewModel
            {
                Id = x.Id,
                CustomerName = x.CustomerName,
                AccountId = x.AccountId,
                OrderStatus = x.OrderStatus,
                TotalAmount = x.TotalAmount,
                DiscountAmount = x.DiscountAmount,
                PayAmount = x.PayAmount,
                IssueTrackingNo = x.IssueTrackingNo,
                RefId = x.RefId,
                PaymentMethodId = x.PaymentMethod,
                CreationDate = x.CreationDate.ToFarsi()
            }).ToList();

            foreach (var order in Query)
            {
                var Result = new PaymentResultOperation();

                if (Result.IsSuccessful)
                {
                    order.IsPaid = true;
                }

                if (order.PaymentMethodId == 1)
                {
                    order.PaymentMethod = "اینترنتی";
                }
                else if(order.PaymentMethodId == 2)
                {
                    order.PaymentMethod = "نقدی";
                }

            }

            if (searchModel.IsCanceled)
            {
                Query = Query.Where(x => x.OrderStatus == OperationOrder.Cancel).ToList();
            }

            if (searchModel.AccountId > 0)
            {
                Query = Query.Where(x => x.AccountId == searchModel.AccountId).ToList();
            }

            return Query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
