using Microsoft.AspNetCore.Mvc;
using ShopManagement.Query;
using ShopManagement.Query.Contracts.ArticleCategory;
using ShopManagement.Query.Contracts.Category;

namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _query;

        private readonly IArticleCategoryQuery _articleqQuery;

        public MenuViewComponent(IProductCategoryQuery query, IArticleCategoryQuery articleqQuery)
        {
            this._query = query;
            _articleqQuery = articleqQuery;
        }

        public IViewComponentResult Invoke()
        {
            var result = new MenuModel
            {
                ArticleCategories = _articleqQuery.GetArticleCategories(),
                ProductCategories = _query.GetProductCategories()
            };
            return View(result);
        }

    }
}
