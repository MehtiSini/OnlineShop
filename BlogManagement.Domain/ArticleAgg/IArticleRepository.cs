using BlogManagement.Contracts.Article;
using MyFramework.Domain;

namespace BlogManagement.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<long,ArticleModel>
    {
        EditArticle GetDetails(long Id);
        List<ArticleViewModel> Search(ArticleSearchModel Search);

    }
}
