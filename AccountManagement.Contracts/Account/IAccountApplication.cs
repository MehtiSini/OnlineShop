using MyFramework.Tools;

namespace AccountManagement.Contracts.Account
{
    public interface IAccountApplication
    {
        OperationResult Register(RegisterAccount cmd);
        OperationResult Edit(EditAccount cmd);
        OperationResult ChangePassword(ChangePassword cmd);
        OperationResult Login(LoginModel cmd);
        void SignOut();
        EditAccount GetDetails(long Id);
        List<AccountViewModel> Search(AccountSearchModel Search);
        string GetProfilePhoto(long Id);
        List<AccountViewModel> GetAccounts();
    }
}
