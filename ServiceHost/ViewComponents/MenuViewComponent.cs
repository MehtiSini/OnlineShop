using Microsoft.AspNetCore.Mvc;
using ShopManagement.Query.Contracts.Category;

namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _query;

        public MenuViewComponent(IProductCategoryQuery query)
        {
            this._query = query;
        }

        public IViewComponentResult Invoke()
        {
            var result = _query.GetCategories();

            return View(result);
        }

    }
}
