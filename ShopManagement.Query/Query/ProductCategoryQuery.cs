using ShopManagement.Infrastructure.ProductCategory.DbContextModel;
using ShopManagement.Query.Contracts.Category;

namespace ShopManagement.Query.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _context;

        public ProductCategoryQuery(ShopContext context)
        {
            _context = context;
        }

        public List<ProductCategoryQueryModel> GetCategories()
        {
            return _context.productCategories.Select(x => new ProductCategoryQueryModel
            {
                Name = x.Name,
                Slug = x.Slug,
                PictureAlt = x.PictureAlt,
                PicturePath = x.PicturePath,
                PictureTitle = x.PictureTitle
            }).ToList();

        }
    }
}
