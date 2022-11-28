using Microsoft.AspNetCore.Mvc;
using ShopManagement.Query.Contracts.Category;

namespace ServiceHost.ViewComponents
{
    public class ProductCategoryWithProductsViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _query;

        public ProductCategoryWithProductsViewComponent(IProductCategoryQuery Query)
        {
            _query = Query;
        }

        public IViewComponentResult Invoke()
        {
            var Result = _query.GetCategoryWithProduct();

            return View(Result);
        }

    }
}
