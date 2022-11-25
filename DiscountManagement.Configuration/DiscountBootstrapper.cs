using DiscountManagement.Application;
using DiscountManagement.Contracts;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.EfCore.CustomerDiscount;
using DiscountManagement.Infrastructure.EfCore.DbContextModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiscountManagement.Configuration
{
    public class DiscountBootstrapper
    {
        public void ConfigService(IServiceCollection service, string ConnString)
        {
            service.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();
            service.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();

            service.AddDbContext<DiscountContext>(x => x.UseSqlServer(ConnString));
        }
    }
}