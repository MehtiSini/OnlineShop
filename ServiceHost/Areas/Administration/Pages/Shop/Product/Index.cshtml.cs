using DiscountManagement.Contracts.CustomerDiscount;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFramework.Tools;
using MyFramework.Tools.Authentication;
using ShopManagement.Configuration.Permission;
using ShopManagement.Contracts.Product;
using Sm.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        public SelectList ProductCategories;

        private readonly IProductCategoryApplication _applicationCategory;

        public ProductSearchModel SearchModel { get; set; }

        public List<ProductViewModel> Products;

        private readonly IProductApplication _application;

        public IndexModel(IProductApplication application, IProductCategoryApplication applicationCategory, ICustomerDiscountApplication discountapplication)
        {
            _application = application;
            _applicationCategory = applicationCategory;
        }

        [NeedPermission(ShopPermissions.CreateProduct)]
        public void OnGet(ProductSearchModel searchModel)
        {
            ProductCategories = new SelectList(_applicationCategory.GetProductCategories(), "Id", "Name");

            Products = _application.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProduct
            {
                Categories = _applicationCategory.GetProductCategories()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateProduct create)
        {
            var result = _application.Create(create);

            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var product = _application.GetDetails(id);

            product.Categories = _applicationCategory.GetProductCategories();

            return Partial("Edit", product);
        }

        public JsonResult OnPostEdit(EditProduct cmd)
        {
            var result = _application.Edit(cmd);

            return new JsonResult(result);
        }
    }
}
