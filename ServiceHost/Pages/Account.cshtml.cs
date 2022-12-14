using AccountManagement.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ServiceHost.Pages
{
    public class AccountModel : PageModel
    {
        [TempData]
        public string? LoginMessage { get; set; }

        private readonly IAccountApplication _accountApplication;

        public AccountModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostLogin(LoginModel Command)
        {
            var Result = _accountApplication.Login(Command);

            if (Result.IsSucceed)
            {
                LoginMessage = Result.Message;
                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Account");
        }

        public IActionResult OnGetSignOut()
        {
            _accountApplication.SignOut();
            return RedirectToPage("./Index");
        }
    }

}
