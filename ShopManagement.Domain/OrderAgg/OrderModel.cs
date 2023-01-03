using MyFramework.Domain;
using MyFramework.Tools;

namespace ShopManagement.Domain.OrderAgg
{
    public class OrderModel : EntityBase
    {
        public long AccountId { get; private set; } 
        public string CustomerName { get; private set; }
        public int PaymentMethod { get; private set; }
        public double DiscountAmount { get; private set; }
        public double TotalAmount { get; private set; }
        public double PayAmount { get; private set; }
        public int OrderStatus { get; private set; }
        public string IssueTrackingNo { get; private set; }
        public long RefId { get; private set; }
        public List<OrderItem>? Items { get; private set; }

        public OrderModel(long accountId,int paymentMethod, double discountAmount, 
            double totalAmount, double payAmount)
        {
            AccountId = accountId;
            PaymentMethod = paymentMethod;
            DiscountAmount = discountAmount;
            PayAmount = payAmount;
            RefId = 0;
            OrderStatus = OperationOrder.Waiting;
            Items = new List<OrderItem>();
            TotalAmount = totalAmount;
        }

        public void Cancel ()
        {
            OrderStatus = OperationOrder.Cancel;
        }

        public void PaymentSucceeded(long refId)
        {
            if(refId != 0 )
            {
                RefId = refId;
            }
        }
        public void SetIssueTrackingNo(string issueTrackingNo )
        {
            IssueTrackingNo = issueTrackingNo;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
    }
}
