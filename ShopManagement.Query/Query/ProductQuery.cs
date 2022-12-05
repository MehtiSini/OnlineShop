using Blog.Domain.Tools;
using DiscountManagement.Infrastructure.EfCore.DbContextModel;
using InventoryManagement.Infrastructure.EfCore.DbContextModel;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Infrastructure.ProductCategory.DbContextModel;
using ShopManagement.Query.Contracts.Product;
using ShopManagement.Query.Contracts.ProductPictures;

namespace ShopManagement.Query.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext _shopcontext;
        private readonly InventoryContext _inventorycontext;
        private readonly DiscountContext _discountcontext;

        public ProductQuery(ShopContext shopcontext, InventoryContext inventorycontext, DiscountContext discountcontext)
        {
            _shopcontext = shopcontext;
            _inventorycontext = inventorycontext;
            _discountcontext = discountcontext;
        }

        public List<ProductQueryModel> GetlatestArrivals()
        {
            var Products = _shopcontext.products.Select(product => new ProductQueryModel
            {
                Id = product.Id,
                Slug = product.Slug,
                Name = product.Name,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                PicturePath = product.PicturePath,
                Category = product.Category.Name,
                CategorySlug = product.Category.Slug

            }).OrderByDescending(x => x.Id).Take(6).ToList();

            var Discount = _discountcontext.CustomerDiscount.Where(x => x.DiscountFinished == false)
                .Select(x => new { x.DiscountRate, x.ProductId }).ToList();

            var Inventory = _inventorycontext.Inventories
                .Select(x => new { x.ProductId, x.UnitPrice }).ToList();

            {
                foreach (var product in Products)
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
            return Products;
        }

        public List<ProductQueryModel> Search(string Value)
        {
            var Discount = _discountcontext.CustomerDiscount.Where(x => x.DiscountFinished == false)
                .Select(x => new { x.DiscountRate, x.ProductId }).AsNoTracking().ToList();

            var Inventory = _inventorycontext.Inventories
                .Select(x => new { x.ProductId, x.UnitPrice }).AsNoTracking().ToList();

            var query = _shopcontext.products.Include(x => x.Category)
                .AsNoTracking()
                .Select(x => new ProductQueryModel
                {
                    Id = x.Id,
                    Slug = x.Slug,
                    Name = x.Name,
                    PictureAlt = x.PictureAlt,
                    PicturePath = x.PicturePath,
                    PictureTitle = x.PictureTitle,
                    Category = x.Category.Name,
                    ShortDescription = x.ShortDescription

                }).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(Value))
            {
                query = query.Where(x => x.Name.Contains(Value) || x.ShortDescription.Contains(Value));
            }
            var Products = query.AsNoTracking().OrderByDescending(x => x.Id).ToList();

            foreach (var product in Products)
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
            return Products;
        }

        public ProductQueryModel GetProductDetails(string Slug)
        {
            var Inventory = _inventorycontext.Inventories
            .Select(x => new { x.ProductId, x.UnitPrice, x.IsInStock }).ToList();

            var Product = _shopcontext.products.Select(product => new ProductQueryModel
            {
                Id = product.Id,
                Slug = product.Slug,
                Name = product.Name,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                PicturePath = product.PicturePath,
                Category = product.Category.Name,
                Code = product.Code,
                CategorySlug = product.Category.Slug,
                ShortDescription = product.ShortDescription,
                Description = product.Description,
                KeyWords = product.Keywords,
                Pictures = MapPictures(product.Pictures)

            }).AsNoTracking().FirstOrDefault(x => x.Slug == Slug);

            if (Product == null)
            {
                return new ProductQueryModel();
            }

            var ProductInventory = Inventory.FirstOrDefault(x => x.ProductId == Product.Id);

            if (ProductInventory != null)
            {
                var Discount = _discountcontext.CustomerDiscount.Where(x => x.DiscountFinished == false)
                  .Select(x => new { x.DiscountRate, x.ProductId, x.EndDate }).ToList();

                var Price = Inventory.FirstOrDefault(x => x.ProductId == Product.Id)
                    .UnitPrice;

                Product.Price = Price.ToMoney();

                Product.InStock = ProductInventory.IsInStock;

                Inventory.FirstOrDefault(x => x.ProductId == Product.Id)
                    .UnitPrice.ToMoney();

                var discount = Discount.FirstOrDefault(x => x.ProductId == Product.Id);

                if (discount != null)
                {
                    var discountrate = discount.DiscountRate;

                    Product.DiscountRate = discountrate;

                    Product.HasDiscount = discountrate > 0;

                    Product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();

                    var DiscountAmount = Math.Round(Price * discountrate) / 100;

                    Product.PriceWithDiscount = (Price - DiscountAmount).ToMoney();
                }
            }

            return Product;
        }

        public static List<ProductPictureQueryModel> MapPictures(List<ProductPictureModel> pictures)
        {
            return pictures.Select(picture => new ProductPictureQueryModel
            {
                ProductId = picture.ProductId,
                PictureAlt = picture.PictureAlt,
                PicturePath = picture.PicturePath,
                PictureTitle = picture.PictureTitle,
                IsRemoved=picture.IsRemoved

            }).Where(x => x.IsRemoved == false).ToList();
        }
    }
}
