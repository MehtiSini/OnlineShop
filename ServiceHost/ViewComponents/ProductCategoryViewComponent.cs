using Microsoft.AspNetCore.Mvc;
using ShopManagement.Query.Contracts.Category;
using Sm.Contracts.ProductCategory;

namespace ServiceHost.ViewComponents
{
    public class ProductCategoryViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _query;

        public ProductCategoryViewComponent(IProductCategoryQuery query)
        {
            _query = query;
        }

        public IViewComponentResult Invoke()
        {
            var Category = _query.GetProductCategories();

            return View(Category);
        }

    }
}
