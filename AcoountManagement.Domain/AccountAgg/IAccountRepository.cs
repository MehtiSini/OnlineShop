using AccountManagement.Contracts.Account;
using MyFramework.Domain;

namespace AcoountManagement.Domain.AccountAgg
{
    public interface IAccountRepository : IRepository<long,AccountModel>
    {
        EditAccount GetDetails(long Id);
        List<AccountViewModel> Search(AccountSearchModel Search);
    }
}
