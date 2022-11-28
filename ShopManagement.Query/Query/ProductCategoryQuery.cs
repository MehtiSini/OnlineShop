using Blog.Domain.Tools;
using DiscountManagement.Infrastructure.EfCore.DbContextModel;
using InventoryManagement.Infrastructure.EfCore.DbContextModel;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.ProductCategory.DbContextModel;
using ShopManagement.Query.Contracts.Category;
using ShopManagement.Query.Contracts.Product;

namespace ShopManagement.Query.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _shopcontext;
        private readonly InventoryContext _inventorycontext;
        private readonly DiscountContext _discountcontext;

        public ProductCategoryQuery(ShopContext context, InventoryContext inventorycontext, DiscountContext discountcontext)
        {
            _shopcontext = context;
            _inventorycontext = inventorycontext;
            _discountcontext = discountcontext;
        }

        public List<ProductCategoryQueryModel> GetCategories()
        {
            return _shopcontext.productCategories.Select(x => new ProductCategoryQueryModel
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
            var Discount = _discountcontext.CustomerDiscount.Where(x => x.DiscountFinished == false)
                .Select(x => new { x.DiscountRate, x.ProductId }).ToList();

            var Inventory = _inventorycontext.Inventories
                .Select(x => new { x.ProductId, x.UnitPrice }).ToList();

            var Categories = _shopcontext.productCategories.Include(x => x.Products)
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
                    ProductsCount = x.Products.Count

                }).Where(x => x.ProductsCount > 0).ToList();

            foreach (var category in Categories)
            {
                foreach (var product in category.Products)
                {
                    var Price = Inventory.FirstOrDefault(x => x.ProductId == product.Id)
                        .UnitPrice;

                    product.Price = Price.ToMoney();

                    Inventory.FirstOrDefault(x => x.ProductId == product.Id)
                        .UnitPrice.ToMoney();

                    var discount = Discount.FirstOrDefault(x => x.ProductId == product.Id);

                    if (discount != null)
                    {
                        var discountrate = discount.DiscountRate;

                        product.DiscountRate = discountrate;

                        product.HasDiscount = discountrate > 0;

                        var DiscountAmount = Math.Round(Price * discountrate) / 100;

                        product.PriceWithDiscount = (Price - DiscountAmount).ToMoney();
                    }
                }
            }
            return Categories;
        }

        public ProductCategoryQueryModel GetCategoryWithProductsBy(string Slug)
        {
            var Discount = _discountcontext.CustomerDiscount.Where(x => x.DiscountFinished == false)
              .Select(x => new { x.DiscountRate, x.ProductId, x.EndDate }).ToList();

            var Inventory = _inventorycontext.Inventories
                .Select(x => new { x.ProductId, x.UnitPrice }).ToList();

            var Category = _shopcontext.productCategories
                .Include(x => x.Products)
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
                    ProductsCount = x.Products.Count,
                    MetaDescription = x.MetaDescription,
                    Description = x.Description,
                    KeyWords = x.KeyWords

                }).FirstOrDefault(x => x.Slug == Slug);

            foreach (var product in Category.Products)
            {
                var Price = Inventory.FirstOrDefault(x => x.ProductId == product.Id)
                    .UnitPrice;

                product.Price = Price.ToMoney();

                Inventory.FirstOrDefault(x => x.ProductId == product.Id)
                    .UnitPrice.ToMoney();

                var discount = Discount.FirstOrDefault(x => x.ProductId == product.Id);

                if (discount != null)
                {
                    var discountrate = discount.DiscountRate;

                    product.DiscountRate = discountrate;

                    product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();

                    product.HasDiscount = discountrate > 0;

                    var DiscountAmount = Math.Round(Price * discountrate) / 100;

                    product.PriceWithDiscount = (Price - DiscountAmount).ToMoney();
                }
            }
            return Category;

        }

        public static List<ProductQueryModel> MapProducts(List<ProductModel> products)
        {
            return products.Select(product => new ProductQueryModel
            {
                Id = product.Id,
                Slug = product.Slug,
                Name = product.Name,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                PicturePath = product.PicturePath,
                Category = product.Category.Name
            }).ToList();
        }

    }
}
