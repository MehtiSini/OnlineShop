using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyFramework.Domain;
using MyFramework.Infrastructure;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastructure.ProductCategory.DbContextModel;
using ShopManagement.Infrastructure.ProductCategory.Repository;
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

            service.AddDbContext<ProductCategoryContext>(x => x.UseSqlServer(ConnString));

        }
    }
}