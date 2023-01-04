using AccountManagement.Contracts.Account;
using AccountManagement.Infrastrucure.EfCore.DbContextModel;
using AcoountManagement.Domain.AccountAgg;
using Blog.Domain.Tools;
using Microsoft.EntityFrameworkCore;
using MyFramework.Infrastructure;
using MyFramework.Tools;
using ShopManagement.Infrastructure.ProductCategory.DbContextModel;

namespace AccountManagement.Infrastrucure.EfCore.Account
{
    public class AccountRepository : RepositoryBase<long, AccountModel>, IAccountRepository
    {
        private readonly AccountContext _accountContext;
        private readonly ShopContext _shopContext;

        public AccountRepository(AccountContext accountContext, ShopContext shopContext) : base(accountContext)
        {
            _accountContext = accountContext;
            _shopContext = shopContext;
        }

        public List<AccountViewModel> GetAccounts()
        {
            var Orders = _shopContext.orders.Select(x => new { x.Id, x.AccountId }).ToList();

            var Accounts = _accountContext.accounts.Select(x => new AccountViewModel
            {
                Id = x.Id,
                FullName = x.FullName
            }).ToList();

            //Combine Two Lists Togethere With The MasterPiece ==> ZIP

            var AccountOrders = Accounts.Zip(Orders, (A,O) => new {account = A , order = O });

            foreach (var item in AccountOrders)
            {
                Accounts = Accounts.Where(x => x.Id == item.order.AccountId).ToList();
            }

            return Accounts;
        }

        public AccountModel GetBy(string Username)
        {
            return _accountContext.accounts.FirstOrDefault(x => x.Username == Username);
        }

        public EditAccount GetDetails(long id)
        {
            return _accountContext.accounts.Select(x => new EditAccount
            {
                Id = x.Id,
                FullName = x.FullName,
                Username = x.Username,
                Mobile = x.Mobile,
                Password = x.Password,
                RoleId = x.RoleId,

            }).FirstOrDefault(x => x.Id == id);
        }

        public string GetProfilePhoto(long id)
        {
            return _accountContext.accounts.FirstOrDefault(x => x.Id == id).ProfilePhoto;
        }

        public List<AccountViewModel> Search(AccountSearchModel Search)
        {
            var Query = _accountContext.accounts.Include(x => x.Role).Select(x => new AccountViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Username = x.Username,
                Mobile = x.Mobile,
                ProfilePhoto = x.ProfilePhoto,
                Role = x.Role.Name,
                RoleId = x.RoleId,
                CreationDate = x.CreationDate.ToFarsi(),
            });


            if (!string.IsNullOrWhiteSpace(Search.FullName))
            {
                Query = Query.Where(x => x.FullName.Contains(Search.FullName));
            }

            if (!string.IsNullOrWhiteSpace(Search.Username))
            {
                Query = Query.Where(x => x.Username.Contains(Search.Username));
            }

            if (!string.IsNullOrWhiteSpace(Search.Mobile))
            {
                Query = Query.Where(x => x.Mobile.Contains(Search.Mobile));
            }

            if (Search.RoleId > 0)
            {
                Query = Query.Where(x => Search.RoleId == x.Id);
            }

            return Query.OrderByDescending(X => X.Id).ToList();
        }
    }
}
