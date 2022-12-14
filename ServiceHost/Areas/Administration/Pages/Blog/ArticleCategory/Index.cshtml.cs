using BlogManagement.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.ArticleCategory
{
    public class IndexModel : PageModel
    {
        public ArticleCategorySearchModel SearchModel { get; set; }

        public List<ArticleCategoryViewModel> ArticleCategories;

        private readonly IArticleCategoryApplication _application;

        public IndexModel(IArticleCategoryApplication application)
        {
            _application = application;
        }

        public void OnGet(ArticleCategorySearchModel searchModel)
        {
            ArticleCategories = _application.Search(searchModel);
        }


        public IActionResult OnGetCreate()
        {
            return Partial("./Register", new CreateArticleCategory());
        }

        public JsonResult OnPostCreate(CreateArticleCategory create)
        {
            var result = _application.Create(create);

            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var category = _application.GetDetails(id);

            return Partial("./Edit", category);
        }

        public JsonResult OnPostEdit(EditArticleCategory cmd)
        {
            var result = _application.Edit(cmd);

            return new JsonResult(result);
        }

    }

}
