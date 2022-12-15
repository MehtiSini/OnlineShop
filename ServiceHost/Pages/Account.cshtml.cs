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

        [TempData]
        public string RegisterMessage { get; set; }

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
                return RedirectToPage("./Index");
            }
            LoginMessage = Result.Message;
            return RedirectToPage("./Account");
        }

        public IActionResult OnGetSignOut()
        {
            _accountApplication.SignOut();
            return RedirectToPage("./Index");
        }

        public IActionResult OnPostRegister(RegisterAccount Command)
        {
            var Result = _accountApplication.Register(Command);

            if (Result.IsSucceed)
            {
                return RedirectToPage("./Index");
            }
            RegisterMessage = Result.Message;
            return new JsonResult(Result);
        }

    }

}
