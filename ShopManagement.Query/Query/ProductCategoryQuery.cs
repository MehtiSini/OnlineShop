using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.ProductCategory.DbContextModel;
using ShopManagement.Query.Contracts.Category;
using ShopManagement.Query.Contracts.Product;

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
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                PictureAlt = x.PictureAlt,
                PicturePath = x.PicturePath,
                PictureTitle = x.PictureTitle

            }).ToList();
        }

        public List<ProductCategoryQueryModel> GetCategoryWithProduct()
        {
            return _context.productCategories.Include(x => x.Products)
                .ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Slug = x.Slug,
                    Name = x.Name,
                    PictureAlt = x.PictureAlt,
                    PicturePath = x.PicturePath,
                    PictureTitle = x.PictureTitle,
                    Products = MapProducts(x.Products),
                    ProductsCount=x.Products.Count

                }).Where(x => x.ProductsCount > 0).ToList();
        }

        public static List<ProductQueryModel> MapProducts(List<ProductModel> products)
        {
            var result = new List<ProductQueryModel>();

            foreach (var product in products)
            {
                var item = new ProductQueryModel
                {
                    Id = product.Id,
                    Slug = product.Slug,
                    Name = product.Name,
                    PictureAlt = product.PictureAlt,
                    PictureTitle = product.PictureTitle,
                    PicturePath = product.PicturePath
                };
                result.Add(item);
            }
            return result;
        }
    }
}
