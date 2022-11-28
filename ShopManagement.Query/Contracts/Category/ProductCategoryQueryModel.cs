using ShopManagement.Query.Contracts.Product;

namespace ShopManagement.Query.Contracts.Category
{
    public class ProductCategoryQueryModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? PicturePath { get; set; }
        public string? PictureAlt { get; set; }
        public string? PictureTitle { get; set; }
        public string? Slug { get; set; }
        public long ProductsCount { get; set; }

        public List<ProductQueryModel>? Products { get; set; }
    }
}
