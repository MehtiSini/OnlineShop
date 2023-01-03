using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFramework.Tools.Authentication;

namespace ServiceHost.Pages
{
    public class PaymentResultModel : PageModel
    {
        public PaymentResultOperation? Result;

        public void OnGet(PaymentResultOperation result)
        {
            Result = result;
        }
    }
}
