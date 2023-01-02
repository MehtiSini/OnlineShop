using BlogManagement.Contracts.ArticleCategory;
using MyFramework.Domain;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository :  IRepository<long,ArticleCategoryModel>
    {
        EditArticleCategory GetDetails(long Id);
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel Search);
        List<ArticleCategoryViewModel> GetArticleCategories();
        string GetSlugById(long Id);

    }
}
