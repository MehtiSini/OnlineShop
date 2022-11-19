using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sm.Application.ProductCategory;
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
    }
}
