using DiscountManagement.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Contracts.Product;

namespace ServiceHost.Areas.Administration.Pages.CustomerDiscount
{
    public class IndexModel : PageModel
    {
        public SelectList Products;

        public CustomerDiscountSearchModel SearchModel { get; set; }

        public List<CustomerDiscountViewModel> Discounts;

        private readonly IProductApplication _productapplication;

        private readonly ICustomerDiscountApplication _discountapplication;

        public IndexModel(IProductApplication productapplication, ICustomerDiscountApplication discountapplication)
        {
            _productapplication = productapplication;
            _discountapplication = discountapplication;
        }

        public void OnGet(CustomerDiscountSearchModel searchModel)
        {
            Products = new SelectList(_productapplication.GetProducts(), "Id", "Name");

            Discounts = _discountapplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new DefineCustomerDiscount
            {
                Products = _productapplication.GetProducts()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(DefineCustomerDiscount create)
        {
            var result = _discountapplication.DefineDiscount(create);

            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var Discount = _discountapplication.GetDetails(id);
            Discount.Products = _productapplication.GetProducts();
            return Partial("Edit", Discount);
        }

        public JsonResult OnPostEdit(EditCustomerDiscount cmd)
        {
            var result = _discountapplication.Edit(cmd);

            return new JsonResult(result);
        }
      
    }
}
