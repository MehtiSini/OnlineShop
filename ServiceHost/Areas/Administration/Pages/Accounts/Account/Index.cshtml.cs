using AccountManagement.Contracts.Account;
using AccountManagement.Contracts.Role;
using DiscountManagement.Contracts.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Contracts.Product;
using Sm.Application.ProductCategory;
using Sm.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Account
{
    public class IndexModel : PageModel
    {
        public SelectList Roles;

        private readonly IAccountApplication _applicationAccount;
        private readonly IRoleApplication _applicationRole;

        public AccountSearchModel? SearchModel { get; set; }

        public List<AccountViewModel>? Accounts;

        public IndexModel(IAccountApplication applicationAccount, IRoleApplication applicationRole)
        {
            _applicationAccount = applicationAccount;
            _applicationRole = applicationRole;
        }

        public void OnGet(AccountSearchModel searchModel)
        {
            Roles = new SelectList(_applicationRole.ListRoles(), "Id", "Name");

            Accounts = _applicationAccount.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateAccount
            {
                Roles = _applicationRole.ListRoles()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateAccount create)
        {
            var result = _applicationAccount.Create(create);

            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var Account = _applicationAccount.GetDetails(id);

            Account.Roles =  _applicationRole.ListRoles();

            return Partial("Edit", Account);
        }

        public JsonResult OnPostEdit(EditAccount cmd)
        {
            var result = _applicationAccount.Edit(cmd);

            return new JsonResult(result);
        }

        public IActionResult OnGetChangePassword(long id)
        {
            var command = new ChangePassword { Id = id };
            return Partial("ChangePassword", command);
        }

        public JsonResult OnPostChangePassword(ChangePassword cmd)
        {
            var result = _applicationAccount.ChangePassword(cmd);

            return new JsonResult(result);
        }

    }
}
