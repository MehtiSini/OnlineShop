using AccountManagement.Applications.Account;
using AccountManagement.Applications.Role;
using AccountManagement.Contracts.Account;
using AccountManagement.Contracts.Role;
using AccountManagement.Infrastrucure.EfCore.Account;
using AccountManagement.Infrastrucure.EfCore.DbContextModel;
using AccountManagement.Infrastrucure.EfCore.Role;
using AcoountManagement.Domain.AccountAgg;
using AcoountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyFramework.Tools;

namespace AccountManagement.Configuration
{
    public class AccountBootstrapper
    {
        public void ConfigService(IServiceCollection service, string ConnString)
        {
            service.AddTransient<IAccountApplication, AccountApplication>();
            service.AddTransient<IAccountRepository, AccountRepository>();

            service.AddTransient<IRoleApplication, RoleApplication>();
            service.AddTransient<IRoleRepository, RoleRepository>();

            service.AddTransient<IPasswordHasher, PasswordHasher>();

            service.AddDbContext<AccountContext>(x => x.UseSqlServer(ConnString));
        }
    }
}
