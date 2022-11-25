namespace DiscountManagement.Contracts.CollegueDiscount
{
    public class CollegueDiscountViewModel
    {
        public long ID { get; set; }
        public long ProductId { get; set; }
        public string? ProductName { get; set; }
        public long DiscountRate { get; set; }
        public bool IsRemoved { get; set; }
        public string? CreationDate { get; set; }
    }

}
