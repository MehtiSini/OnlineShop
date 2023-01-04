namespace ShopManagement.Contracts.Orders
{
    public class OrderViewModel
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public string? CustomerName { get; set; }
        public int PaymentMethodId { get; set; }
        public string? PaymentMethod { get; set; }
        public double DiscountAmount { get; set; }
        public double TotalAmount { get; set; }
        public double PayAmount { get; set; }
        public int OrderStatus { get; set; }
        public bool IsPaid { get; set; }
        public string? IssueTrackingNo { get; set; }
        public string? CreationDate { get; set; }
        public long RefId { get; set; }
    }
}
