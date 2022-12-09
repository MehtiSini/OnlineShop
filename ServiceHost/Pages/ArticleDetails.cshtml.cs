using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Query.Contracts.Article;
using ShopManagement.Query.Contracts.ArticleCategory;

namespace ServiceHost.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleQueryModel Article;
        public List<ArticleQueryModel> LatestArticles;
        public List<ArticleCategoryQueryModel> ArticleCategories;

        private readonly IArticleQuery _query;
        private readonly IArticleCategoryQuery _categoryQuery;

        public ArticleDetailsModel(IArticleQuery query, IArticleCategoryQuery categoryQuery)
        {
            _query = query;
            _categoryQuery = categoryQuery;
        }

        public void OnGet(string Id)
        {
            Article = _query.GetArticleDetails(Id);
            LatestArticles=_query.GetLatestArticles();
            ArticleCategories = _categoryQuery.GetArticleCategories();
        }
    }
}
