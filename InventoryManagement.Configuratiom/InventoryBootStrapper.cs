using InventoryManaement.Domain.InventoryAgg;
using InventoryManagement.Application.Inventory;
using InventoryManagement.Conracts.Inventory;
using InventoryManagement.Infrastructure.EfCore.DbContextModel;
using InventoryManagement.Infrastructure.EfCore.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManaement.Configuration
{
    public class InventoryBootStrapper
    {
        public void ConfigService(IServiceCollection service , string ConnString)
        {

            service.AddTransient<IInventoryApplication, InventoryApplication>();
            service.AddTransient<IInventoryRepository, InventoryRepository>();

            service.AddDbContext<InventoryContext>(x => x.UseSqlServer(ConnString));

        }
    }
}