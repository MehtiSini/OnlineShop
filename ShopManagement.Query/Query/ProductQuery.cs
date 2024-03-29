﻿using Blog.Domain.Tools;
using CommentManagement.Domain.CommentAgg;
using CommentManagement.Infrastructure.EfCore;
using CommentManagement.Infrastructure.EfCore.DbContextModel;
using CommentManagement.Query.Contracts.Comment;
using DiscountManagement.Infrastructure.EfCore.DbContextModel;
using InventoryManagement.Infrastructure.EfCore.DbContextModel;
using Microsoft.EntityFrameworkCore;
using MyFramework.Tools;
using ShopManagement.Contracts.Orders;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Infrastructure.ProductCategory.DbContextModel;
using ShopManagement.Query.Contracts.Product;
using ShopManagement.Query.Contracts.ProductPictures;

namespace ShopManagement.Query.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext _shopcontext;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;
        private readonly CommentContext _commentContext;

        public ProductQuery(ShopContext shopcontext, InventoryContext inventorycontext, DiscountContext discountcontext, CommentContext commentContext)
        {
            _shopcontext = shopcontext;
            _inventoryContext = inventorycontext;
            _discountContext = discountcontext;
            _commentContext = commentContext;
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

            var Discount = _discountContext.CustomerDiscount.Where(x => x.DiscountFinished == false)
                 .Select(x => new { x.DiscountRate, x.ProductId, x.EndDate, x.StartDate }).ToList();

            var Inventory = _inventoryContext.Inventories
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

                        if (discount.EndDate <= discount.StartDate)
                        {
                            product.HasDiscount = false;
                        }

                        var DiscountAmount = Math.Round(Price * discountrate) / 100;

                        product.PriceWithDiscount = (Price - DiscountAmount).ToMoney();
                    }
                }
            }
            return Products;
        }

        public List<ProductQueryModel> Search(string Value)
        {
            var Discount = _discountContext.CustomerDiscount.Where(x => x.DiscountFinished == false)
                .Select(x => new { x.DiscountRate, x.ProductId }).AsNoTracking().ToList();

            var Inventory = _inventoryContext.Inventories
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
            var Inventory = _inventoryContext.Inventories
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
                MetaDescription = product.MetaDescription,
                KeyWords = product.Keywords,
                Pictures = MapPictures(product.Pictures),
            }).AsNoTracking().FirstOrDefault(x => x.Slug == Slug);

            if (Product == null)
            {
                return new ProductQueryModel();
            }

            var ProductInventory = Inventory.FirstOrDefault(x => x.ProductId == Product.Id);

            if (ProductInventory != null)
            {
                var Discount = _discountContext.CustomerDiscount.Where(x => x.DiscountFinished == false)
                  .Select(x => new { x.DiscountRate, x.ProductId, x.EndDate, x.StartDate }).ToList();

                var Price = Inventory.FirstOrDefault(x => x.ProductId == Product.Id)
                    .UnitPrice;

                Product.Price = Price.ToMoney();

                Product.DoublePrice = Price;

                Product.InStock = ProductInventory.IsInStock;

                Inventory.FirstOrDefault(x => x.ProductId == Product.Id)
                    .UnitPrice.ToMoney();

                var discount = Discount.FirstOrDefault(x => x.ProductId == Product.Id);

                if (discount != null)
                {
                    var discountrate = discount.DiscountRate;

                    Product.DiscountRate = discountrate;

                    if (discount.EndDate <= discount.StartDate)
                    {
                        Product.HasDiscount = false;
                    }

                    Product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();

                    var DiscountAmount = Math.Round(Price * discountrate) / 100;

                    Product.PriceWithDiscount = (Price - DiscountAmount).ToMoney();
                }

                Product.Comments = _commentContext.comments
               .Where(x => x.Type == CommentType.Product)
               .Where(x => x.OwnerRecordId == Product.Id)
               .Where(x => x.CommentStatus == OperationComment.Confirm)
               .Select(x => new CommentQueryModel
               {
                   Id = x.Id,
                   Message = x.Message,
                   Name = x.Name,
                   CreationDate = x.CreationDate.ToFarsi()
               }).OrderByDescending(x => x.Id).ToList();
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
                IsRemoved = picture.IsRemoved

            }).Where(x => x.IsRemoved == false).ToList();
        }

        //private static List<CommentQueryModel> MapComments(List<CommentModel> Comments)
        //{
        //    return Comments.Select(comment => new CommentQueryModel
        //    {
        //        Id = comment.Id,
        //        CreationDate = comment.CreationDate.ToFarsi(),
        //        Name = comment.Name,
        //        Message = comment.Message,
        //        CommentStatus = comment.CommentStatus

        //    }).Where(x => x.CommentStatus == OperationComment.Confirm).OrderByDescending(x => x.Id).ToList();

        //}


        public List<CartItem> CheckInventoryStatus(List<CartItem> cartItems)
        {
            var Inventory = _inventoryContext.Inventories.ToList();

            foreach (var item in cartItems.Where
                (cartItem => Inventory.Any(x => x.ProductId == cartItem.Id && x.IsInStock == OperationStock.InStock)))
            {
                var ProductInventory = _inventoryContext.Inventories.FirstOrDefault(x => x.ProductId == item.Id);
             
                //if(ProductInventory.CalculateCurrentCount() < item.Count)
                //{
                //    item.IsInStock = false;
                //}

                item.IsInStock = ProductInventory.CalculateCurrentCount() >= item.Count;
            }

            return cartItems;
        }
    }
}
