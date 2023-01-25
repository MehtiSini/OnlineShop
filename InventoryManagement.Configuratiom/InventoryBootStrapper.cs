using InventoryManaement.Domain.InventoryAgg;
using InventoryManagement.Application.Inventory;
using InventoryManagement.Configuratiom.Permission;
using InventoryManagement.Contracts.Inventory;
using InventoryManagement.Infrastructure.EfCore.DbContextModel;
using InventoryManagement.Infrastructure.EfCore.Inventory;
using InventoryManagement.Query.Contracts;
using InventoryManagement.Query.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyFramework.Tools.Authentication;

namespace InventoryManagement.Configuration
{
    public class InventoryBootStrapper
    {
        public void ConfigService(IServiceCollection service , string ConnString)
        {
            service.AddTransient<IInventoryApplication, InventoryApplication>();
            service.AddTransient<IInventoryRepository, InventoryRepository>();

            service.AddTransient<IPermissionExposer, InventoryPermissionExposer>();
            service.AddTransient<IInventoryQuery, InventoryQuery>();

            service.AddDbContext<InventoryContext>(x => x.UseSqlServer(ConnString));
        }
    }
}