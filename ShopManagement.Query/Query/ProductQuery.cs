using ShopManagement.Query.Contracts.Category;
using ShopManagement.Query.Contracts.Product;
using DiscountManagement.Infrastructure.EfCore.DbContextModel;
using InventoryManagement.Infrastructure.EfCore.DbContextModel;
using ShopManagement.Infrastructure.ProductCategory.DbContextModel;
using Blog.Domain.Tools;

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

            }).OrderByDescending(x=>x.Id).Take(6).ToList();

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

       
    }
}
