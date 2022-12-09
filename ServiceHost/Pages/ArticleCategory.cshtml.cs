using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Query.Contracts.Article;
using ShopManagement.Query.Contracts.ArticleCategory;

namespace ServiceHost.Pages
{
    public class ArticleCategoryModel : PageModel
    {
        public ArticleCategoryQueryModel ArticleCategory;
        public List<ArticleCategoryQueryModel>  ArticleCategories;
        public List<ArticleQueryModel>  LatestArticles;

        private readonly IArticleCategoryQuery _query;
        private readonly IArticleQuery _articleQuery;

        public ArticleCategoryModel(IArticleCategoryQuery query, IArticleQuery articleQuery)
        {
            _query = query;
            _articleQuery = articleQuery;
        }

        public void OnGet(string Id)
        {
            ArticleCategory = _query.GetArticleCategoryDetails(Id);
            LatestArticles = _articleQuery.GetLatestArticles();
            ArticleCategories = _query.GetArticleCategories();

        }
    }
}
