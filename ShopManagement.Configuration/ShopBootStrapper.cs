﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyFramework.Domain;
using MyFramework.Infrastructure;
using ShopManagement.Application.Product;
using ShopManagement.Application.ProductPicture;
using ShopManagement.Contracts.Product;
using ShopManagement.Contracts.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Infrastructure.EfCore.Product;
using ShopManagement.Infrastructure.EfCore.ProductCategory;
using ShopManagement.Infrastructure.EfCore.ProductPicture;
using ShopManagement.Infrastructure.ProductCategory.DbContextModel;
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

            service.AddDbContext<ShopContext>(x => x.UseSqlServer(ConnString));

        }
    }
}