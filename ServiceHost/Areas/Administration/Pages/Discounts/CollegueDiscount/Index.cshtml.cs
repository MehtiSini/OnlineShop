using DiscountManagement.Contracts.CollegueDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Contracts.Product;

namespace ServiceHost.Areas.Administration.Pages.CollegueDiscount
{
    public class IndexModel : PageModel
    {
        public SelectList Products;

        public CollegueDiscountSearchModel SearchModel { get; set; }

        public List<CollegueDiscountViewModel> Discounts;

        private readonly IProductApplication _productapplication;

        private readonly ICollegueDiscountApplication _discountapplication;

        public IndexModel(IProductApplication productapplication, ICollegueDiscountApplication discountapplication)
        {
            _productapplication = productapplication;
            _discountapplication = discountapplication;
        }

        public void OnGet(CollegueDiscountSearchModel searchModel)
        {
            Products = new SelectList(_productapplication.GetProducts(), "Id", "Name");
            Discounts = _discountapplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new DefineCollegueDiscount
            {
                Products = _productapplication.GetProducts()
            };
            return Partial("./Register", command);
        }

        public JsonResult OnPostCreate(DefineCollegueDiscount create)
        {
            var result = _discountapplication.Define(create);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var Discount = _discountapplication.GetDetails(id);
            Discount.Products = _productapplication.GetProducts();
            return Partial("Edit", Discount);
        }

        public JsonResult OnPostEdit(EditCollegueDiscount cmd)
        {
            var result = _discountapplication.Edit(cmd);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            _discountapplication.Remove(id);

            return RedirectToPage("./Index");
        }

        public IActionResult OnGetActivate(long id)
        {
            _discountapplication.Activate(id);

            return RedirectToPage("./Index");
        }

    }
}
