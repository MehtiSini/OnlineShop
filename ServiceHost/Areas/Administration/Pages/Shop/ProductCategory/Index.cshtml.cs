using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sm.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategory
{
    public class IndexModel : PageModel
    {
        public ProductCategorySearchModel SearchModel { get; set; }

        public List<ProductCategoryViewModel> ProductCategories;

        private readonly IProductCategoryApplication _application;

        public IndexModel(IProductCategoryApplication application)
        {
            _application = application;
        }

        public void OnGet(ProductCategorySearchModel searchModel)
        {
            ProductCategories = _application.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }

        public JsonResult OnPostCreate(CreateProductCategory create)
        {
            var result = _application.Create(create);

            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productcategory = _application.GetDetails(id);

            return Partial("./Edit", productcategory);
        }

        public JsonResult OnPostEdit(EditProductCategory cmd)
        {
           
            var result = _application.Edit(cmd);

            return new JsonResult(result);
        }

    }
}
