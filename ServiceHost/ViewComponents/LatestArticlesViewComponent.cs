using Microsoft.AspNetCore.Mvc;
using ShopManagement.Query.Contracts.Article;

namespace ServiceHost.ViewComponents
{
    public class LatestArticlesViewComponent  : ViewComponent
    {
        private readonly IArticleQuery _query;

        public LatestArticlesViewComponent(IArticleQuery query)
        {
            _query = query;
        }

        public IViewComponentResult Invoke()
        {
            var Article = _query.GetLatestArticles();

            return View(Article);
        }

    }
}
