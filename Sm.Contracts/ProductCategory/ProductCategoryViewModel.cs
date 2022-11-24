namespace Sm.Contracts.ProductCategory
{
    public class ProductCategoryQueryModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? PicturePath { get; set; }
        public string? CreationDate { get; set; }
        public long ProductsCount { get; set; }
    }
}
