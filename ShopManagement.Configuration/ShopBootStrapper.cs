﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyFramework.Tools.Authentication;
using Shop.Infrastructure.InventoryAcl;
using ShopManagement.Application.Cart;
using ShopManagement.Application.Contracts.Orders;
using ShopManagement.Application.Order;
using ShopManagement.Application.Product;
using ShopManagement.Application.ProductPicture;
using ShopManagement.Application.Slide;
using ShopManagement.Configuration.Permission;
using ShopManagement.Contracts.Orders;
using ShopManagement.Contracts.Product;
using ShopManagement.Contracts.ProductPicture;
using ShopManagement.Contracts.Slide;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.Services;
using ShopManagement.Domain.SlideAgg;
using ShopManagement.Infrastructure.EfCore.Order;
using ShopManagement.Infrastructure.EfCore.Product;
using ShopManagement.Infrastructure.EfCore.ProductCategory;
using ShopManagement.Infrastructure.EfCore.ProductPicture;
using ShopManagement.Infrastructure.EfCore.Slide;
using ShopManagement.Infrastructure.ProductCategory.DbContextModel;
using ShopManagement.Query.Contracts.Cart;
using ShopManagement.Query.Contracts.Category;
using ShopManagement.Query.Contracts.Product;
using ShopManagement.Query.Contracts.Slide;
using ShopManagement.Query.Query;
using Sm.Application.ProductCategory;
using Sm.Contracts.ProductCategory;

namespace ShopManagement.Configuration
{
    public class ShopBootStrapper
    {
        public void ConfigService(IServiceCollection service , string ConnString)
        {
            service.AddTransient<IProductCategoryRepository , ProductCategoryRepository>();
            service.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();

            service.AddTransient<IProductApplication, ProductApplicaiton>();
            service.AddTransient<IProductRepository, ProductRepository>();

            service.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            service.AddTransient<IProductPictureRepository, ProductPictureRepository>();

            service.AddTransient<ISlideApplication, SlideApplication>();
            service.AddTransient<ISlideRepository, SlideRepository>();

            service.AddTransient<ISlideQuery, SlideQuery>();
            service.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();
            service.AddTransient<IProductQuery, ProductQuery>();

            service.AddTransient<IPermissionExposer, ShopPermissionExposer>();
            service.AddTransient<ICartCalculator, CartCalculator>();
            service.AddTransient<IShopInventoryAcl, ShopInventoryAcl>();

            service.AddTransient<IOrderApplication, OrderApplication>();
            service.AddTransient<IOrderRepository, OrderRepository>();

            service.AddSingleton<ICartService, CartService>();

            service.AddDbContext<ShopContext>(x => x.UseSqlServer(ConnString));
        }
    }
}