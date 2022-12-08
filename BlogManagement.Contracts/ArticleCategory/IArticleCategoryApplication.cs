using MyFramework.Tools;

namespace BlogManagement.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        OperationResult Create(CreateArticleCategory cmd);
        OperationResult Edit(EditArticleCategory cmd);
        EditArticleCategory GetDetails(long Id);
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel Search);
        List<ArticleCategoryViewModel> GetArticleCategories();
    }
}
