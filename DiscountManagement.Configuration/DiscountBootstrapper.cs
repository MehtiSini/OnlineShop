using DiscountManagement.Application.CollegueDiscount;
using DiscountManagement.Application.CustomerDiscount;
using DiscountManagement.Contracts.CollegueDiscount;
using DiscountManagement.Contracts.CustomerDiscount;
using DiscountManagement.Domain.CollegueDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.EfCore.CollegueDiscount;
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

            service.AddTransient<ICollegueDiscountApplication, CollegueDiscountApplication>();
            service.AddTransient<ICollegueDiscountRepository, CollegueDiscountRepository>();

            service.AddDbContext<DiscountContext>(x => x.UseSqlServer(ConnString));
        }
    }
}