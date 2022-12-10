using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Query.Contracts.Category;

namespace ServiceHost.Pages
{
    public class ProductCategoryModel : PageModel
    {
        public ProductCategoryQueryModel ProductCategory { get; set; }


        private readonly IProductCategoryQuery _query;

        public ProductCategoryModel(IProductCategoryQuery query)
        {
            _query = query;
        }

        public void OnGet(string Id)
        {
            ProductCategory = _query.GetCategoryWithProductsBy(Id);
        }
    }
}
