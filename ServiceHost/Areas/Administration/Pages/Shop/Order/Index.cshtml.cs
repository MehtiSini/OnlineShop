using AccountManagement.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Contracts.Orders;

namespace ServiceHost.Areas.Administration.Pages.Shop.Order
{
    public class IndexModel : PageModel
    {
        //We Get Customer List from Account
        public SelectList? Customers;

        public OrderSearchModel? SearchModel { get; set; }
        public List<OrderViewModel>? Orders;
        private readonly IOrderApplication? _orderApplication;
        private readonly IAccountApplication? _accountApplication;

        public IndexModel(IOrderApplication? orderapplication, IAccountApplication? accountApplication)
        {
            _orderApplication = orderapplication;
            _accountApplication = accountApplication;
        }

        public void OnGet(OrderSearchModel searchModel)
        {
            Customers = new SelectList(_accountApplication.GetAccounts(), "Id", "FullName");

            Orders = _orderApplication.Search(searchModel);
        }

        public IActionResult OnGetConfirm(long id)
        {
            _orderApplication.Confirm(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetCancel(long id)
        {
            _orderApplication.Cancel(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetItems(long OrderId)
        {
            var Items = _orderApplication.GetItems(OrderId);

            return Partial("Items", Items);
        }

    }
}
