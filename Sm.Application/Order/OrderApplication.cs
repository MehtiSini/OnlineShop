using MyFramework.Tools;
using MyFramework.Tools.Authentication;
using ShopManagement.Contracts.Orders;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Application.Order
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IAuthHelper _authHelper;
        private readonly IOrderRepository _orderRepository;
        public OrderApplication(IOrderRepository orderRepository, IAuthHelper authHelper)
        {
            _orderRepository = orderRepository;
            _authHelper = authHelper;
        }

        public long PlaceOrder(CartDetail Cart)
        {
            var CurrentAcountId = _authHelper.GetCurrentAccountId();
            var Order = new OrderModel(CurrentAcountId,Cart.PaymentMethod,Cart.DiscountAmount,Cart.TotalAmount,Cart.PayAmount);

            foreach (var item in Cart.CartItems)
            {
                var OrderItem = new OrderItem(item.Id,item.Count,item.DiscountRate,item.UnitPrice);
                Order.AddItem(OrderItem);
            }
            _orderRepository.Create(Order);
            _orderRepository.Save();
            return Order.Id;
        }
        public double GetAmountBy(long Id)
        {
            return _orderRepository.GetAmountBy(Id);
        }

        public string PaymentSucceeded(long orderId, long refId)
        {
            var Order = _orderRepository.GetById(orderId);
            Order.PaymentSucceeded(refId);
            var IssueTrackingNo = CodeGenerator.Generate("S");
            Order.SetIssueTrackingNo(IssueTrackingNo);
            return IssueTrackingNo;
        }
    }
}
