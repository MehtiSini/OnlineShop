namespace ShopManagement.Contracts.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public double UnitPrice { get; set; }
        public string? PicturePath { get; set; }
        public string? CategoryName { get; set; }
        public string? CreationDate { get; set; }
        public long CategoryId { get; set; }
        public int InStock { get; set; }
    }

}
