using AccountManagement.Contracts.Account;
using MyFramework.Domain;

namespace AcoountManagement.Domain.AccountAgg
{
    public interface IAccountRepository : IRepository<long,AccountModel>
    {
        AccountModel GetBy(string Username);
        EditAccount GetDetails(long Id);
        List<AccountViewModel> Search(AccountSearchModel Search);
        string GetProfilePhoto(long Id);
        List<AccountViewModel> GetAccounts();
    }
}
