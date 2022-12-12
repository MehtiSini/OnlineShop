using AccountManagement.Contracts.Account;
using AcoountManagement.Domain.AccountAgg;
using MyFramework.Domain;
using System.Linq.Expressions;

namespace AccountManagemnt.Infrastructure
{
    public class AccountRepository : IRepository<long, AccountModel>, IAccountRepository
    {

        public void Create(AccountModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Exist(Expression<Func<AccountModel, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<AccountModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public AccountModel GetById(long Id)
        {
            throw new NotImplementedException();
        }

        public EditAccount GetDetails(long Id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public List<AccountViewModel> Search(AccountSearchModel Search)
        {
            throw new NotImplementedException();
        }
    }
}
