using MyFramework.Tools;

namespace AccountManagement.Contracts.Account
{
    public interface IAccountApplication
    {
        OperationResult Create(CreateAccount cmd);
        OperationResult Edit(EditAccount cmd);
        OperationResult ChangePassword(ChangePassword cmd);
        OperationResult Login(LoginModel cmd);
        void SignOut();
        EditAccount GetDetails(long Id);
        List<AccountViewModel> Search(AccountSearchModel Search);
    }
}
