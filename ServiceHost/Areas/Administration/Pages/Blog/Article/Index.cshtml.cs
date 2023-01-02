using BlogManagement.Contracts.Article;
using BlogManagement.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.Article
{
    public class IndexModel : PageModel
    {
        public ArticleSearchModel SearchModel { get; set; }

        public List<ArticleViewModel> Articles;

        public SelectList Categories;

        private readonly IArticleApplication _application;
        private readonly IArticleCategoryApplication _categoryApplication;

        public IndexModel(IArticleApplication application, IArticleCategoryApplication categoryApplication)
        {
            _application = application;
            _categoryApplication = categoryApplication;
        }

        public void OnGet(ArticleSearchModel searchModel)
        {
            Categories = new SelectList(_categoryApplication.GetArticleCategories(), "Id", "Name");
            Articles = _application.Seacrh(searchModel);
        }

    }
}
